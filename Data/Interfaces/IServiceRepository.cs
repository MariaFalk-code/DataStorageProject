using Data.Entities;

namespace Data.Interfaces;

public interface IServiceRepository : IBaseRepository<ServiceEntity>
{
    Task<ServiceEntity?> GetServiceWithCustomerAndUsageAsync(int ServiceId);
    Task<IEnumerable<ServiceEntity>> GetAllServicesWithUsageAsync();
}
