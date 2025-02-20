using Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string OrganizationNumber { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ContactInfo? ContactInfo { get; set; }
    public List<Address>? Addresses { get; set; }
    public List<Project>? Projects { get; set; }
}

