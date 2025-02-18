using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    //Get specific customer with related data
    public async Task<CustomerEntity?> GetCustomerWithAddressesAsync(int customerId)
    {
        try {
                return await base._context.Customers
                .Include(c => c.CustomerAddresses)
                    .ThenInclude(ca => ca.Address)
                .FirstOrDefaultAsync(c => c.Id == customerId);
            }

        catch (Exception ex) { throw new Exception("Could not retrieve customer with related addresses", ex); }
    }
    public Task<CustomerEntity?> GetCustomerWithAllContactDetailsAsync(int customerId)
    {
        throw new NotImplementedException();
    }
    public Task<CustomerEntity?> GetCustomerWithAllRelatedDataAsync(int customerId)
    {
        throw new NotImplementedException();
    }
    public Task<CustomerEntity?> GetCustomerWithProjectsAsync(int customerId)
    {
        throw new NotImplementedException();
    }
    public Task<CustomerEntity?> GetCustomerWithContactInfoAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    //Get all customers with related data
    public Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAddressesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAllContactDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerEntity>> GetAllCustomersWithContactInfoAsync()
    {
        throw new NotImplementedException();
    }





}
