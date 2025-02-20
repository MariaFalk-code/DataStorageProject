using Business.Models;
using Data.Entities;

namespace Business.Factories;

//Code provided by Chat GPT4o. A flexible factory that can create a project object with optional additional properties
//based on what conditions are passed in the method call in ProjectService.
public static class ProjectFactory
{
    public static Project Create(ProjectEntity entity, bool includeManager = false, bool includeCustomer = false, bool includeServiceUsages = false)
    {
        var project = new Project
        {
            ProjectNumber = entity.ProjectNumber,
            Name = entity.Name,
            Description = entity.Description,
            Status = new Status
            {
                Id = entity.Status.Id,
                Name = entity.Status.Name
            }
        };

        if (includeManager && entity.Manager is not null)
            project.Manager = EmployeeFactory.Create(entity.Manager);

        if (includeCustomer && entity.Customer is not null)
            project.Customer = CustomerFactory.Create(entity.Customer);

        if (includeServiceUsages && entity.ServiceUsages is not null)
            project.ServiceUsages = entity.ServiceUsages
                .Select(su => ServiceUsageFactory.Create(su, su.Service))
                .ToList();

        return project;
    }
}

