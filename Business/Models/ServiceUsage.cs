namespace Business.Models;

public class ServiceUsage
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = null!;
    public string ProjectNumber { get; set; } = null!;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
    public decimal TotalPrice { get; set; }
}
