using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Runtime.CompilerServices;

namespace Business.Services;

public class ProjectService(
    IProjectRepository projectRepository,
    IServiceUsageRepository serviceUsageRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IServiceUsageRepository _serviceUsageRepository = serviceUsageRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var projectEntity = await ProjectFactory.CreateEntity(model, _projectRepository);

        try
        {
            await _projectRepository.CreateAsync(projectEntity);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not create project", ex);
        }
    }
    public async Task<Project?> GetProjectAsync(string projectNumber)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.ProjectNumber == projectNumber);
            return projectEntity is not null ? ProjectFactory.Create(projectEntity) : null;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not get project", ex);
        }
    }
    public async Task<Project?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber)
    {
        try
        {
            var projectEntity = await _projectRepository.GetProjectWithCustomerAndServiceUsageAsync(projectNumber);
            return projectEntity is not null ? ProjectFactory.Create(projectEntity, includeCustomer: true, includeManager: true, includeServiceUseage: true) : null;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not get project", ex);
        }
    }
    public async Task<IEnumerable<Project>> GetProjectsByStatusAsync(int statusId)
    {
        try
        {
            var projectEntities = await _projectRepository.GetAllProjectsByStatusAsync(statusId);
            return projectEntities
                .Select(p => ProjectFactory.Create(p, includeCustomer: true, includeManager: true))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not get projects", ex);
        }
    }
    public async Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateModel updatedModel)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.ProjectNumber == projectNumber);
            if (projectEntity is null)
            {
                return false;
            }
            if (updatedModel != null)
            ProjectFactory.UpdateEntity(updatedModel, projectEntity);
            await _projectRepository.UpdateAsync(projectEntity);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not update project", ex);
        }
    }
    public async Task<bool> DeleteProjectAsync(string projectNumber)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.ProjectNumber == projectNumber);
            if (projectEntity is null)
            {
                return false;
            }

            bool hasServiceUsage = await _serviceUsageRepository.ExistsAsync(su => su.ProjectNumber == projectEntity.ProjectNumber);

            if (hasServiceUsage)
                Console.WriteLine($"⚠️ Project {projectEntity.ProjectNumber} has related services.");
            Console.Write("Are you sure you want to delete it? (y/n): ");
             char confirmation = Console.ReadKey().KeyChar;

            if (char.ToLower(confirmation) != 'y')
            {
                Console.WriteLine("\n Deletion canceled.");
                return false;
            }
            await _projectRepository.DeleteAsync(p => p.ProjectNumber == projectNumber);
            Console.WriteLine($"Project {projectEntity.ProjectNumber} deleted successfully!");
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not delete project", ex);
        }
    }
}
