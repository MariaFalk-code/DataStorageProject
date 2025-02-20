namespace Business.Models;

public class ContactInfo
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? ContactPerson { get; set; }
}
