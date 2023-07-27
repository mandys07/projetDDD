using Bibliotheque.Domain.Entities;

namespace Bibliotheque.Domain.Agregats;

public class Librairy
{
    public Guid Id { get; set; }
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }
    public List<Borrowing> Borrowings { get;}
}
