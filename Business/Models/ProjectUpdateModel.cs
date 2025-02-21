using Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ProjectUpdateModel
{
    [StringLength(100, ErrorMessage = "Project name must be at most 100 characters.")]
    public string? Name { get; set; }

    [StringLength(500, ErrorMessage = "Description must be at most 500 characters.")]
    public string? Description { get; set; }

    public int? StatusId { get; set; }
    public int? ManagerId { get; set; }

    [EndDateAfterStartDate]
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}


