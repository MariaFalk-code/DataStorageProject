using Business.Models;
using Business.Resources;
using Data.Entities;
using Data.Interfaces;

namespace Business.Factories;

//Entity to model conversion method
public static class ProjectFactory
{
    public static Project Create(ProjectEntity entity, bool includeCustomer = false, bool includeManager = false, bool includeServiceUseage = false)
    {
        var project = new Project
        {
            ProjectNumber = entity.ProjectNumber,
            Name = entity.Name,
            Description = entity.Description,
            Status = new Status { Id = entity.Status.Id, Name = entity.Status.Name },
            StartDate = entity.StartDate,
            EndDate = (DateTime)entity.EndDate!,
        };

        if (includeCustomer && entity.Customer is not null)
            project.Customer = CustomerFactory.Create(entity.Customer, includeContact: false, includeAddresses: false, includeProjects: false);

        if (includeManager && entity.Manager is not null)
            project.Manager = EmployeeFactory.Create(entity.Manager);

        if (includeServiceUseage && entity.ServiceUsages is not null)
            project.ServiceUsages = entity.ServiceUsages
                .Select(su => ServiceUsageFactory.Create(su, su.Service))
                .ToList();
        return project;
    }

    public static async Task<ProjectEntity> CreateEntity(ProjectRegistrationModel model, IProjectRepository projectRepository)
    {
        var projectNumber = await ProjectNumberGenerator.GenerateAsync(projectRepository);

        return new ProjectEntity
        {
            ProjectNumber = projectNumber,
            Name = model.Name,
            Description = model.Description,
            StatusId = 1, // Default: "Not Started"
            CustomerId = model.CustomerId,
            ManagerId = model.ManagerId,
            StartDate = model.StartDate,
            EndDate = (DateTime)model.EndDate!
        };
    }
}

