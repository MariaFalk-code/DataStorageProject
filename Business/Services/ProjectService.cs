using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Resources;
using Data.Interfaces;
using System.Runtime.CompilerServices;

namespace Business.Services;

public class ProjectService(
    ICustomerRepository customerRepository,
    IProjectRepository projectRepository,
    IServiceUsageRepository serviceUsageRepository,
    IServiceRepository serviceRepository) : IProjectService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IServiceUsageRepository _serviceUsageRepository = serviceUsageRepository;
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationModel model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

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
            ProjectFactory.UpdateEntity(updatedModel, projectEntity, _projectRepository);
            await _projectRepository.UpdateAsync(projectEntity);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not update project", ex);
        }
    }
    public Task<bool> DeleteProjectAsync(string projectNumber)
    {
        throw new NotImplementedException();
    }
}
