using Business.Models;
using Data.Entities;

public class Customer
{
    public int Id { get; set; }
    public string OrganizationNumber { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ContactInfo? ContactInfo { get; set; }
    public List<Address>? Addresses { get; set; }
    public List<Project>? Projects { get; set; }

    public Customer(CustomerEntity entity)
    {
        Id = entity.Id;
        OrganizationNumber = entity.OrganizationNumber;
        Name = entity.Name;

        if (entity.ContactInfo is not null)
            ContactInfo = new ContactInfo(entity.ContactInfo);

        if (entity.CustomerAddresses is not null)
            Addresses = entity.CustomerAddresses.Select(ca => new Address(ca.Address)).ToList();

        if (entity.Projects is not null)
            Projects = entity.Projects.Select(p => new Project(p)).ToList();
    }
}

