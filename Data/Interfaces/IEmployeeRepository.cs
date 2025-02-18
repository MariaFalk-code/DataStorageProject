using Data.Entities;

namespace Data.Interfaces;
public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
{
    Task<EmployeeEntity?> GetEmployeeWithActiveProjectsAsync(int employeeId);
    Task<IEnumerable<EmployeeEntity>> GetAllEmployeesWithActiveProjectsAsync();
}
