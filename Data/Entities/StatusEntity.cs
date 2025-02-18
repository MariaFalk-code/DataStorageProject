using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!; // "Not Started", "Ongoing", "Completed"

    // Navigation properties
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
