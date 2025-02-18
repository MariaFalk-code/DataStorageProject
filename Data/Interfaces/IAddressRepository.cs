using Data.Entities;

namespace Data.Interfaces;

public interface IAddressRepository : IBaseRepository<AddressEntity>
{
    Task<AddressEntity?> GetAddressWithCustomersAsync(int AddressId);
}
