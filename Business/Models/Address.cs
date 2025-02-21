namespace Business.Models;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string? Country { get; set; } = null!;
    public string AddressType { get; set; } = null!;
}
