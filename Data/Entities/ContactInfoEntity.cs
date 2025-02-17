using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ContactInfoEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string? ContactPerson { get; set; }

    [Required]
    [MaxLength(255)]
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    // Navigation properties
    public CustomerEntity Customer { get; set; } = null!;
}
