using Business.Models;
using Business.Resources;
using Data.Entities;
using Data.Interfaces;

namespace Business.Factories;

//Code provided by Chat GPT4o. A flexible factory that can create a project object with optional additional properties
//based on what conditions are passed in the method call in ProjectService.
//Entity to model conversion method
public static class ProjectFactory
{
    public static Project Create(ProjectEntity entity)
    {
        var project = new Project
        {
            ProjectNumber = entity.ProjectNumber,
            Name = entity.Name,
            Description = entity.Description,
        };
        return project;
    }

    //Model to entities conversion method
    public static async Task<ProjectEntity> CreateEntity(ProjectRegistrationModel model, IProjectRepository projectRepository)
    {
        var projectNumber = await ProjectNumberGenerator.GenerateAsync(projectRepository);

        return new ProjectEntity
        {
            ProjectNumber = projectNumber,
            Name = model.Name,
            Description = model.Description,
            StatusId = 1,
            CustomerId = model.CustomerId,
            ManagerId = model.ManagerId,
            StartDate = model.StartDate,
            EndDate = (DateTime)model.EndDate!
        };
    }
}

