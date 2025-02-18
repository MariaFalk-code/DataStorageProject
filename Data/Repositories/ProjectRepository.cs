using Data.Context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
    {
        public Task<IEnumerable<ProjectEntity>> GetAllProjectsByStatusAsync(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEntity?> GetProjectWithCustomerAndServiceUsageAsync(string ProjectNumber)
        {
            throw new NotImplementedException();
        }
    }
}
