using Business.Models;

namespace Business.Interfaces;

public interface ICustomerService
{
    //Methods concerning single customer
    Task<bool> CreateCustomerAsync(Customer customer);
    Task<Customer?> GetCustomerAsync(int id);
    //Task<Customer> GetCustomerWithActiveProjectsAsync(int id);
   // Task<Customer> GetCustomerWithAllRelatedDataAsync(int id);
    Task<bool> UpdateCustomerAsync(int customerId,Customer updatedCustomer);
    Task<bool> DeleteCustomerAsync(int id);

    //Methods concerning all customers
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
   // Task<IEnumerable<Customer>> GetAllCustomersWithAllRelatedDataAsync();
}

