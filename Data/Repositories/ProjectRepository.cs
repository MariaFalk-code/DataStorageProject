using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
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
            .Include(p => p.ServiceUsages)
            .ThenInclude(su => su.Service)
            .FirstOrDefaultAsync(p => p.ProjectNumber == projectNumber);
    }
}
