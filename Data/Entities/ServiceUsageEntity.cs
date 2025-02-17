using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceUsageEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Quantity { get; set; }

    [ForeignKey("Service")]
    public int ServiceId { get; set; }

    [ForeignKey("Project")]
    public string ProjectNumber { get; set; } = null!;

    // Navigation properties
    public ServiceEntity Service { get; set; } = null!;
    public ProjectEntity Project { get; set; } = null!;
}
