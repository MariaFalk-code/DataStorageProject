using Data.Entities;

namespace Business.Factories;

//Code provided by Chat GPT4o. A flexible factory that can create a Customer object with optional additional properties
//based on what conditions are passed in the method call in CustomerService.
public static class CustomerFactory
{
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
}

