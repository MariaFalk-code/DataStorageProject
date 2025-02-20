using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{
    public static Service CreateService(ServiceEntity service)
    {
        return new Service
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            Unit = service.Unit
        };

    }
}
