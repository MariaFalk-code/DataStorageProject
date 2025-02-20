namespace Business.Models;

public class CustomerUpdateModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? OrganizationNumber { get; set; }
    public ContactInfoUpdateModel? ContactInfo { get; set; }
    public List<AddressUpdateModel>? Addresses { get; set; }
}
