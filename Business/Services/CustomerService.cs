using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(
    ICustomerRepository customerRepository,
    IContactInfoRepository contactInfoRepository,
    IAddressRepository addressRepository,
    ICustomerAddressRepository customerAddressRepository,
    IProjectRepository projectRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IContactInfoRepository _contactInfoRepository = contactInfoRepository;
    private readonly IAddressRepository _addressRepository = addressRepository;
    private readonly ICustomerAddressRepository _customerAddressRepository = customerAddressRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationModel model)
    {
        if (model == null)
            return false;

        var (customer, contactInfo, addresses, customerAddresses) = CustomerFactory.CreateEntities(model);

        try {
        await _customerRepository.CreateAsync(customer);

            if (customer != null)
                contactInfo.CustomerId = customer.Id;

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

            var contactInfo = customer.ContactInfo is not null
                ? await _contactInfoRepository.GetAsync(ci => ci.Id == customer.ContactInfo.Id)
                : null;

            var addresses = await _addressRepository.GetAllAsync(a => a.CustomerAddresses.Any(ca => ca.CustomerId == id))
                ?? new List<AddressEntity>();

            CustomerFactory.UpdateEntities(customer, updatedModel, contactInfo!, addresses);

            await _customerRepository.UpdateAsync(customer);
            if (contactInfo is not null)
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
            // Checks if customer has related projects
            var hasProjects = await _projectRepository.GetAsync(p => p.Customer.Id == id) is not null;
            if (hasProjects)
            {
                Console.WriteLine($"Cannot delete customer {id} because they have related projects. Please first delete any projects related to this customer and then try again.");
                return false;
            }

            return await _customerRepository.DeleteAsync(c => c.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not delete customer", ex);
        }
    }

}
