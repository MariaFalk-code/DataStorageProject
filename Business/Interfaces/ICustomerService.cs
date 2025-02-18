using Business.Models;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<bool> UpdateCustomerAsync(int customerId,Customer updatedCustomer);
    Task<bool> DeleteCustomerAsync(int customerId);
}
