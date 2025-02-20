using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class AddressFactory
{
    public static Address Create(AddressEntity address, CustomerAddressEntity customerAddress)
    {
        return new Address
        {
            Id = address.Id,
            Street = address.Street,
            StreetNumber = address.StreetNumber,
            City = address.City,
            PostalCode = address.PostalCode,
            Country = address.Country,
            AddressType = customerAddress.Type
        };
    }
}
