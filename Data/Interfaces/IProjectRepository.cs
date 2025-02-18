﻿using Data.Entities;

namespace Data.Interfaces
{
    public interface IProjectRepository : IBaseRepository<ProjectEntity>
    {
        Task<IEnumerable<ProjectEntity>> GetAllProjectsByStatusAsync(int statusId);
        Task<ProjectEntity?> GetProjectWithCustomerAndServiceUsageAsync(string ProjectNumber);
    }
}
