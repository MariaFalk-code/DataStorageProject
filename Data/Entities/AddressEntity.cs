
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Street { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string StreetNumber { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string PostalCode { get; set; } = null!;

    [MaxLength(50)]
    public string? Country { get; set; }


    // Navigation properties
    public ICollection<CustomerAddressEntity> CustomerAddresses { get; set; } = [];
}
