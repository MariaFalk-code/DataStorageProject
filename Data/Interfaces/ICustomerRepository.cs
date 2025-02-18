using Data.Entities;

namespace Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    //Get specific customer with related data
    Task<CustomerEntity?> GetCustomerWithContactDetailsAsync(int customerId);
    Task<CustomerEntity?>GetCustomerWithActiveProjectsAsync(int customerId);
    Task<CustomerEntity?>GetCustomerWithAllRelatedDataAsync(int customerId);

    //Get all customers with related data
    Task<IEnumerable<CustomerEntity>> GetAllCustomersWithContactInfoAsync();
    Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAllContactDetailsAsync();
}
