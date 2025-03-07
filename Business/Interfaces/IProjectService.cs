﻿using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationModel project);
    Task<bool> HasRelatedServiceUsagesAsync(string projectNumber);
    Task<Project?> GetProjectAsync(string projectNumber);
    Task<Project?> GetProjectWithCustomerAndServiceUsageAsync(string projectNumber);
    Task<IEnumerable<Project>> GetProjectsByStatusAsync(int statusid);
    Task<bool> UpdateProjectAsync(string projectNumber, ProjectUpdateModel updatedProject);
    Task<bool> DeleteProjectAsync(string projectNumber);
}
