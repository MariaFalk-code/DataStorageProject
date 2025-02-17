using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerAddressEntity
{
    // Composite key
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [ForeignKey("Address")]
    public int AddressId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Type { get; set; } = null!; // "Billing or "Postal"

    // Navigation properties
    public CustomerEntity Customer { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;
}
