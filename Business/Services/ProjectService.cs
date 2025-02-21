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

    public Task<bool> DeleteProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<Project?> GetProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status)
    {
        throw new NotImplementedException();
    }

    public Task<Project?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProjectAsync(int projectId, ProjectUpdateModel updatedProject)
    {
        throw new NotImplementedException();
    }
}
