using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(13)]
    [Column(TypeName = "varchar(13)")]
    public string OrganizationNumber { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    // Navigation properties
    public ContactInfoEntity ContactInfo { get; set; } = null!;
    public ICollection<CustomerAddressEntity> CustomerAddresses { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
