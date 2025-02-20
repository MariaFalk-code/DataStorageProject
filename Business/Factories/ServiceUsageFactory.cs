using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceUsageFactory
{
    public static ServiceUsage Create(ServiceUsageEntity serviceUsage, ServiceEntity service)
    {
        return new ServiceUsage
        {
            Id = serviceUsage.Id,
            ServiceId = serviceUsage.ServiceId,
            ServiceName = service.Name,
            ProjectNumber = serviceUsage.ProjectNumber,
            Quantity = serviceUsage.Quantity,
            Price = service.Price,
            Unit = service.Unit,
        };
    }
}
