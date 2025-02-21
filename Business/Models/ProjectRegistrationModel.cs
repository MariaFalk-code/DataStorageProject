using Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

//Updated with DataAnnotations by ChatGPT4o.
public class ProjectRegistrationModel
{
    [Required(ErrorMessage = "Project name is required.")]
    [StringLength(100, ErrorMessage = "Project name must be at most 100 characters.")]
    public string Name { get; set; } = null!;

    [StringLength(2000, ErrorMessage = "Description must be at most 2000 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "A customer must be assigned to the project.")]
    public int CustomerId { get; set; }

    public int? ManagerId { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [EndDateAfterStartDate]
    public DateTime? EndDate { get; set; }
}

