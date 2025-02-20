namespace Business.Models
{
    public class Project
    {
        public string ProjectNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int StatusId { get; set; }
        public string Status { get; set; } = null!;
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; } = null!;
        public ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();
    }
}
