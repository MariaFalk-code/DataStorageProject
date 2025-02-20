namespace Business.Models;

public class CustomerRegistrationModel
{
    public string Name { get; set; } = null!;
    public string OrganizationNumber { get; set; } = null!;

    // Contact Info
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ContactPerson { get; set; } = null!;

    // Addresses (can have multiple)
    public List<AddressInputModel> Addresses { get; set; } = new();
}

public class AddressInputModel
{
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string? Country { get; set; }
    public string AddressType { get; set; } = null!; // Billing, Postal, etc.
}
