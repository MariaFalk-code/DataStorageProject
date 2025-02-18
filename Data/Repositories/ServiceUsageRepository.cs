using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServiceUsageRepository(DataContext context) : BaseRepository<ServiceUsageEntity>(context), IServiceUsageRepository
{

    public async Task<decimal> GetTotalCostByProjectAsync(string projectNumber)
    {
        return await base._context.ServiceUsages
            .Where(su => su.Project.ProjectNumber == projectNumber)
            .SumAsync(su => su.Quantity * su.Service.Price);

    }
    public async Task<IEnumerable<ServiceUsageEntity>> GetServiceUsageByProjectAsync(string projectNumber)
    {
        return await base._context.ServiceUsages
            .Include(su => su.Service)
            .Where(su => su.Project.ProjectNumber == projectNumber)
            .ToListAsync();
    }
}
