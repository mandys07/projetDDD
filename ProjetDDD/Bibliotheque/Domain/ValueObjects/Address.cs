namespace Bibliotheque.Domain.ValueObjects;

public class Address
{
    public string? Number { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
