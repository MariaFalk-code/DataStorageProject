using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ContactInfoFactory
{
    public static ContactInfo CreateContactInfo(ContactInfoEntity entity)
    {
        return new ContactInfo
        {
            Id = entity.Id,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            ContactPerson = entity.ContactPerson
        };
    }
}
