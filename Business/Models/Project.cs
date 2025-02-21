namespace Business.Models
{
    public class Project
    {
        public string ProjectNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Status Status { get; set; } = null!;
        public Employee? Manager { get; set; }
        public Customer Customer { get; set; } = null!;
        
        public List<ServiceUsage>? ServiceUsages { get; set; }
}
}
