namespace Business.Models;

public class ContactInfoUpdateModel
{
    public int ContactId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactPerson { get; set; }
}
