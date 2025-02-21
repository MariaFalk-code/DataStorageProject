using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        return await base._context.Projects
            .Include(p => p.Status)
            .FirstOrDefaultAsync(expression);
    }
    public async Task<ProjectEntity?> GetLatestProjectAsync()
    {
        return await _context.Projects
            .OrderByDescending(p => p.ProjectNumber)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<ProjectEntity>> GetAllProjectsByStatusAsync(int statusId)
    {
        return await base._context.Projects
            .Where(p => p.StatusId == statusId)
            .Include(p => p.Status)
            .Include(p => p.Manager)
            .ToListAsync();
    }

    public async Task<ProjectEntity?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber)
    {
        return await base._context.Projects
            .Include(p => p.Customer)
            .Include(p => p.Status)
            .Include(p => p.Manager)
            .Include(p => p.ServiceUsages)
            .ThenInclude(su => su.Service)
            .FirstOrDefaultAsync(p => p.ProjectNumber == projectNumber);
    }
}
