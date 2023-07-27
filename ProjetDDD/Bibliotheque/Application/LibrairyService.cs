using Bibliotheque.Domain.Agregats;
using Bibliotheque.Domain.Entities;
using Bibliotheque.Domain.Events;

namespace Bibliotheque.Application;

public class LibrairyService
{
    private readonly Librairy _librairy;

    public LibrairyService(Librairy librairy)
    {
        _librairy = librairy;
    }

    public List<Book> GetListBooks()
    {
        return _librairy.Books;
    }

    public List<Member> GetListMembers()
    {
        return _librairy.Members;
    }

    public List<Borrowing> GetListBorrowings()
    {
        return _librairy.Borrowings;
    }

    public void BorrowBook(Guid bookId, Guid memberId, DateTime borrowingDate)
    {
        // Check si livre dispo

        var borrowing = new Borrowing
        {
            Id = Guid.NewGuid(),
            BookId = bookId,
            MemberId = memberId,
            BorrowingDate = DateTime.Now,
            ReturnDate = null
        };

        _librairy.Borrowings.Add(borrowing);

        var eventBorrowing = new BookBorrowingEvent
        {
            BookId = bookId,
            MemberId = memberId,
            BorrowingDate = DateTime.Now
        };

        // Emission evenement pour l'enregistrer

    }
}
