using Bibliotheque.Domain.ValueObjects;

namespace Bibliotheque.Domain.Entities;

public class Member
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Address? Address { get; set; }
}
