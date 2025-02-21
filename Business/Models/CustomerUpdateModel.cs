using System.ComponentModel.DataAnnotations;

namespace Business.Models;

// Updated with DataAnnotations by ChatGPT4o.
public class CustomerUpdateModel
{
    [Required(ErrorMessage = "Customer ID is required.")]
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Customer name must be at most 100 characters.")]
    public string? Name { get; set; }

    [RegularExpression(@"^\d{6}-\d{4}$", ErrorMessage = "Organization number must be in the format XXXXXX-XXXX.")]
    public string? OrganizationNumber { get; set; }

    public List<AddressUpdateModel>? Addresses { get; set; }

    // Contact Info
        [Required(ErrorMessage = "Contact ID is required.")]
        public int ContactId { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }
        [StringLength(100, ErrorMessage = "Contact person name must be at most 100 characters.")]
        public string? ContactPerson { get; set; }

    // Address Updates
    public class AddressUpdateModel
    {
        public int? Id { get; set; } // Nullable to allow adding new addresses

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Street number is required.")]
        public string StreetNumber { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal code must be exactly 5 digits.")]
        public string PostalCode { get; set; } = null!;

        public string? Country { get; set; }

        [Required(ErrorMessage = "Address type is required (Billing, Postal, etc.).")]
        public string AddressType { get; set; } = null!;
    }
}

