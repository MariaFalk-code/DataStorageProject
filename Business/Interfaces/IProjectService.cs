using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationModel project);
    Task<Project?> GetProjectAsync(int projectId);
    Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status);
    Task<bool> UpdateProjectAsync(int projectId, ProjectUpdateModel updatedProject);
    Task<bool> DeleteProjectAsync(int projectId);
    Task<Project?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber);
}
