using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    //Code provided by Chat GPT4o. A flexible factorypattern that can create a Customer object with optional additional properties
    //based on what conditions are passed in the method call in CustomerService.

    //Entity to model conversion method
    public static Customer Create(CustomerEntity entity, bool includeContact = false, bool includeAddresses = false, bool includeProjects = false)
    {
        var customer = new Customer
        {
            Id = entity.Id,
            OrganizationNumber = entity.OrganizationNumber,
            Name = entity.Name
        };

        if (includeContact && entity.ContactInfo is not null)
            customer.ContactInfo = ContactInfoFactory.Create(entity.ContactInfo);

        if (includeAddresses && entity.CustomerAddresses is not null)
            customer.Addresses = entity.CustomerAddresses
                .Select(ca => AddressFactory.Create(ca.Address, ca))
                .ToList();

        if (includeProjects && entity.Projects is not null)
            customer.Projects = entity.Projects
                .Select(p => ProjectFactory.Create(p))
                .ToList();

        return customer;
    }

    //Model to entity conversion method
    //This method is used to create the different relevant entities from the model object. ChatGPT4o generated the code after my prompts.
    public static (CustomerEntity, ContactInfoEntity, List<AddressEntity>, List<CustomerAddressEntity>) CreateEntities(CustomerRegistrationModel model)
    {
        // Create CustomerEntity
        var customerEntity = new CustomerEntity
        {
            Name = model.Name,
            OrganizationNumber = model.OrganizationNumber
        };

        // Create ContactInfoEntity
        var contactInfoEntity = new ContactInfoEntity
        {
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            ContactPerson = model.ContactPerson
        };

        // Create AddressEntities
        var addressEntities = model.Addresses.Select(a => new AddressEntity
        {
            Street = a.Street,
            StreetNumber = a.StreetNumber,
            City = a.City,
            PostalCode = a.PostalCode,
            Country = a.Country
        }).ToList();

        // Create CustomerAddressEntities (linking Customer and Address)
        var customerAddressEntities = new List<CustomerAddressEntity>();
        for (int i = 0; i < model.Addresses.Count; i++)
        {
            customerAddressEntities.Add(new CustomerAddressEntity
            {
                Customer = customerEntity,
                Address = addressEntities[i],
                Type = model.Addresses[i].AddressType
            });
        }

        return (customerEntity, contactInfoEntity, addressEntities, customerAddressEntities);
    }

    // Method for updating entites based on an update model. ChatGPT4o helped generate this code as well after my prompts.
    // Allows for partial updates based on the model passed.
    public static void UpdateEntities(CustomerEntity customer, CustomerUpdateModel model, ContactInfoEntity contactInfo, List<AddressEntity> addresses)
    {
        if (!string.IsNullOrWhiteSpace(model.Name))
            customer.Name = model.Name;

        if (!string.IsNullOrWhiteSpace(model.OrganizationNumber))
            customer.OrganizationNumber = model.OrganizationNumber;

        if (string.IsNullOrWhiteSpace(model.Email))
            contactInfo.Email = model.Email ?? contactInfo.Email;
        if (string.IsNullOrWhiteSpace(model.PhoneNumber))
            contactInfo.PhoneNumber = model.PhoneNumber ?? contactInfo.PhoneNumber;
        if (string.IsNullOrWhiteSpace(model.ContactPerson))
            contactInfo.ContactPerson = model.ContactPerson ?? contactInfo.ContactPerson;

        if (model.Addresses is not null)
        {
            foreach (var addr in model.Addresses)
            {
                var existingAddress = addresses.FirstOrDefault(a => a.Id == addr.Id);
                if (existingAddress is not null)
                {
                    existingAddress.Street = addr.Street;
                    existingAddress.StreetNumber = addr.StreetNumber;
                    existingAddress.City = addr.City;
                    existingAddress.PostalCode = addr.PostalCode;
                    existingAddress.Country = addr.Country;
                }
            }
        }
    }

}


