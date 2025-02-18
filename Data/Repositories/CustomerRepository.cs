using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    //Get specific customer with related data
    public async Task<CustomerEntity?> GetCustomerWithContactDetailsAsync(int customerId)
    {
        try
        {
            return await base._context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.CustomerAddresses)
                    .ThenInclude(ca => ca.Address)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }
        catch (Exception ex) { throw new Exception("Could not retrieve customer with related contact details", ex); }
    }
    public async Task<CustomerEntity?> GetCustomerWithActiveProjectsAsync(int customerId)
    {
        try
        {
            return await base._context.Customers
            .Include(c => c.Projects.Where(p => p.Status.Name != "Completed"))
                .ThenInclude(p => p.Status)
            .FirstOrDefaultAsync(c => c.Id == customerId);
        }
        catch (Exception ex) { throw new Exception("Could not retrieve customer with related projects", ex); }
    }
    public async Task<CustomerEntity?> GetCustomerWithAllRelatedDataAsync(int customerId)
    {
        try
        {
            return await base._context.Customers
            .Include(c => c.ContactInfo)
            .Include(c => c.CustomerAddresses)
                .ThenInclude(ca => ca.Address)
            .Include(c => c.Projects)
                .ThenInclude(p => p.Status)
            .FirstOrDefaultAsync(c => c.Id == customerId);
        }
        catch (Exception ex) { throw new Exception("Could not retrieve customer with all related data", ex); }
    }

    //Get all customers with related data
    public async Task<IEnumerable<CustomerEntity>> GetAllCustomersWithContactInfoAsync()
    {
        try
        {
            return await base._context.Customers
            .Include(c => c.ContactInfo)
            .ToListAsync();
        }
        catch (Exception ex) { throw new Exception("Could not retrieve customers with related contact info", ex); }
    }
    public async Task<IEnumerable<CustomerEntity>> GetAllCustomersWithAllContactDetailsAsync()
    {
        try {
            return await base._context.Customers
            .Include(c => c.ContactInfo)
            .Include(c => c.CustomerAddresses)
                .ThenInclude(ca => ca.Address)
            .ToListAsync();
        }
        catch (Exception ex) { throw new Exception("Could not retrieve customers with related contact details", ex); }
    }
}
