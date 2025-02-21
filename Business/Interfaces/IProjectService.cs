using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationModel project);
    Task<Project?> GetProjectAsync(string projectNumber);
    Task<Project?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber);
    Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status);
    Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateModel updatedProject);
    Task<bool> DeleteProjectAsync(string projectNumber);
}
