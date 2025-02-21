namespace Business.Models;

public class ProjectUpdateModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? StatusId { get; set; }
    public int? ManagerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

