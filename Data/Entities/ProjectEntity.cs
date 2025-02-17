using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    [MaxLength(20)]
    [Column(TypeName = "varchar(20)")]
    public string ProjectNumber { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(4000)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Required]
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [ForeignKey("Status")]
    public int StatusId { get; set; }

    [ForeignKey(nameof(Manager))]
    public int ManagerId { get; set; }

    // Navigation properties
    public CustomerEntity Customer { get; set; } = null!;
    public StatusEntity Status { get; set; } = null!;
    public EmployeeEntity Manager { get; set; } = null!;
    public ICollection<ServiceUsageEntity> ServiceUsages { get; set; } = [];
}
