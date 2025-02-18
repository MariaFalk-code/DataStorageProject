using Data.Entities;

namespace Data.Interfaces;

public interface IServiceUsageRepository : IBaseRepository<ServiceUsageEntity>
{
    Task<IEnumerable<ServiceUsageEntity>> GetServiceUsageByProjectAsync(string projectNumber);
    Task<decimal> GetTotalCostByProjectAsync(string projectNumber);
}

