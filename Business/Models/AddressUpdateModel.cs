namespace Business.Models;

public class AddressUpdateModel
{
    public int? Id { get; set; }  // Nullable to allow for new addresses
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string? Country { get; set; }
    public string AddressType { get; set; } = null!;
}
