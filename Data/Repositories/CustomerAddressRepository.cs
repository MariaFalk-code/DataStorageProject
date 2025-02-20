using Data.Context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CustomerAddressRepository(DataContext context) : BaseRepository<CustomerAddressEntity>(context), ICustomerAddressRepository
{
}
