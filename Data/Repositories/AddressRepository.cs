using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AddressRepository(DataContext context) : BaseRepository<AddressEntity>(context), IAddressRepository
{
    public async Task<AddressEntity?> GetAddressWithCustomersAsync(int addressId)
    {
        return await base._context.Addresses
            .Include(a => a.CustomerAddresses)
                .ThenInclude(ca => ca.Customer)
            .FirstOrDefaultAsync(a => a.Id == addressId);
    }
}
