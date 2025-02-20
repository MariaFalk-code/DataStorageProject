using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateCustomerAsync(Customer customer)
    {
        if (customer == null)
            return false;

        return await _customerRepository.CreateAsync(customer);
    }
    public async Task<Customer?> GetCustomerAsync(int id)
    {
        return await _customerRepository.GetCustomerWithContactDetailsAsync(id);
    }

    public async Task<bool> UpdateCustomerAsync(int customerId, Customer updatedCustomer)
    {
        var customer = await _customerRepository.GetCustomerWithContactDetailsAsync(customerId);
        if (customer == null)
            return false;

        return await _customerRepository.PartialUpdateAsync(updatedCustomer);
    }
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        return await _customerRepository.DeleteAsync(id);
    }
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllCustomersWithContactInfoAsync();
    }
}
