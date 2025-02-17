using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class EmployeeEntity
{
    [Key]
    public int EmployeeNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    // Navigation properties
    public ICollection<ProjectEntity> ManagedProjects { get; set; } = [];
}
