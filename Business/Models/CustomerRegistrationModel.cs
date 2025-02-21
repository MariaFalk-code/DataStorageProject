using System.ComponentModel.DataAnnotations;

namespace Business.Models;

//Updated with DataAnnotations by ChatGPT4o.
public class CustomerRegistrationModel
{
    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(100, ErrorMessage = "Customer name must be at most 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Organization number is required.")]
    [RegularExpression(@"^\d{6}-\d{4}$", ErrorMessage = "Organization number must be in the format XXXXXX-XXXX.")]
    public string OrganizationNumber { get; set; } = null!;

    // Contact Info
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Contact person is required.")]
    [StringLength(100, ErrorMessage = "Contact person name must be at most 100 characters.")]
    public string ContactPerson { get; set; } = null!;

    // Addresses (Must have at least one)
    [MinLength(1, ErrorMessage = "At least one address must be provided.")]
    public List<AddressInputModel> Addresses { get; set; } = [];
}

public class AddressInputModel
{
    [Required(ErrorMessage = "Street is required.")]
    public string Street { get; set; } = null!;

    [Required(ErrorMessage = "Street number is required.")]
    public string StreetNumber { get; set; } = null!;

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required.")]
    public string PostalCode { get; set; } = null!;

    public string? Country { get; set; }

    [Required(ErrorMessage = "Address type is required (Billing, Postal, etc.).")]
    public string AddressType { get; set; } = null!;
}

