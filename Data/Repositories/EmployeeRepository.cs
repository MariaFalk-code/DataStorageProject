using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{

    public async Task<EmployeeEntity?> GetEmployeeWithActiveProjectsAsync(int employeeNumber)
    {
        return await base._context.Employees
            .Include(e => e.ManagedProjects.Where(p => p.Status.Name != "Completed"))
            .ThenInclude(p => p.Status)
            .FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber);
    }
    public async Task<IEnumerable<EmployeeEntity>> GetAllEmployeesWithActiveProjectsAsync()
    {
        return await base._context.Employees
            .Where(e => e.ManagedProjects.Any(p => p.Status.Name != "Completed"))
            .Include(e => e.ManagedProjects.Where(p => p.Status.Name != "Completed"))
                .ThenInclude(p => p.Status)
            .ToListAsync();
    }
}
