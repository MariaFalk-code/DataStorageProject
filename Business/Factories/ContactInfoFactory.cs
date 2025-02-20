using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ContactInfoFactory
{
    public static ContactInfo CreateContactInfo(ContactInfoEntity contactInfo)
    {
        return new ContactInfo
        {
            Id = contactInfo.Id,
            Email = contactInfo.Email,
            PhoneNumber = contactInfo.PhoneNumber,
            ContactPerson = contactInfo.ContactPerson
        };
    }
}
