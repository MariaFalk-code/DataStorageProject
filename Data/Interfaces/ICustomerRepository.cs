using Data.Entities;

namespace Data.Interfaces;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    //Get specific customer with related data
    Task<CustomerEntity?> GetCustomerWithAddressesAsync(int customerId);
    Task<CustomerEntity?> GetCustomerWithContactInfoAsync(int customerId);
    Task<CustomerEntity?> GetCustomerWithAllContactDetailsAsync(int customerId);
    Task<CustomerEntity?>GetCustomerWithProjectsAsync(int customerId);
    Task<CustomerEntity?>GetCustomerWithAllRelatedDataAsync(int customerId);

    //Get all customers with related data
    Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAddressesAsync();
    Task<IEnumerable<CustomerEntity>> GetAllCustomersWithContactInfoAsync();
    Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAllContactDetailsAsync();
}
