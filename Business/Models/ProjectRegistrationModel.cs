namespace Business.Models;

public class ProjectRegistrationModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int CustomerId { get; set; }
    public int? ManagerId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
  
    
}
