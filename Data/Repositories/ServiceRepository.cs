using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    public async Task<ServiceEntity?> GetServiceWithCustomerAndUsageAsync(int ServiceId)
    {
        return await base._context.Services
            .Include(s => s.ServiceUsages)
                .ThenInclude(su => su.Project.Customer)
            .FirstOrDefaultAsync(s => s.Id == ServiceId);
    }
    public async Task<IEnumerable<ServiceEntity>> GetAllServicesWithUsageAsync()
    {
        return await base._context.Services
            .Include(s => s.ServiceUsages)
            .ToListAsync();
    }
}
