using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(
    ICustomerRepository customerRepository,
    IContactInfoRepository contactInfoRepository,
    IAddressRepository addressRepository,
    ICustomerAddressRepository customerAddressRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IContactInfoRepository _contactInfoRepository = contactInfoRepository;
    private readonly IAddressRepository _addressRepository = addressRepository;
    private readonly ICustomerAddressRepository _customerAddressRepository = customerAddressRepository;

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationModel model)
    {
        if (model == null)
            return false;

        var (customer, contactInfo, addresses, customerAddresses) = CustomerFactory.CreateEntities(model);

        try {
        await _customerRepository.CreateAsync(customer);
        await _contactInfoRepository.CreateAsync(contactInfo);
        foreach (var address in addresses)
            await _addressRepository.CreateAsync(address);
        foreach (var customerAddress in customerAddresses)
            await _customerAddressRepository.CreateAsync(customerAddress);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not create customer", ex);
        }

        return true;
    }
    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetCustomerWithContactDetailsAsync(id);
        return customerEntity is not null ? CustomerFactory.Create(customerEntity, includeContact: true) : null;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllCustomersWithContactInfoAsync();
            return customers.Select(c => CustomerFactory.Create(c, includeContact: true)).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve customers", ex);
        }
    }
    public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateModel updatedModel)
    {
        try
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == id);
            if (customer == null)
                return false;

            var contactInfo = await _contactInfoRepository.GetAsync(ci => ci.Id == customer.ContactInfo.Id);
            var addresses = await _addressRepository.GetAllAsync(a => a.CustomerAddresses.Any(ca => ca.CustomerId == id));

            CustomerFactory.UpdateEntities(customer, updatedModel, contactInfo!, addresses);

            await _customerRepository.UpdateAsync(customer);
            if (contactInfo != null)
                await _contactInfoRepository.UpdateAsync(contactInfo);
            foreach (var address in addresses)
                await _addressRepository.UpdateAsync(address);

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not update customer", ex);
        }
    }
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        try
        {
            return await _customerRepository.DeleteAsync(c => c.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not delete customer", ex);
        }
    }
}
