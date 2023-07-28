using Bibliotheque.Domain.Agregats;
using Bibliotheque.Domain.Entities;
using Bibliotheque.Domain.Events;
using Bibliotheque.Infrastructure;
using Bibliotheque.Infrastructure.Persistance;
using System;
using System.Net;

namespace Bibliotheque.Application;

public interface ILibrairyService
{
    List<Book> GetListBooks();
    List<Member> GetListMembers();
    List<Borrowing> GetListBorrowings();
    void BorrowBook(Guid bookId, Guid memberId, DateTime borrowingDate);
}
public class LibrairyService
{
    private readonly Librairy _librairy;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly BorrowingsRepository _borrowingsRepository;

    public LibrairyService(Librairy librairy, IEventDispatcher eventDispatcher, BorrowingsRepository borrowingsRepository)
    {
        _librairy = librairy;
        _eventDispatcher = eventDispatcher;
        _borrowingsRepository = borrowingsRepository;
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
        if (CheckIfBookNotAvailable(bookId))
        {
            throw new Exception("Not available");
        }
        else
        {
            CreateBorrowing(bookId, memberId, borrowingDate);
        }
    }

    public void CreateBorrowing(Guid bookId, Guid memberId, DateTime borrowingDate)
    {
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

        _eventDispatcher.Dispatch(eventBorrowing);
    }

    public bool CheckIfBookNotAvailable(Guid bookId)
    {
        var borrowings = _borrowingsRepository.GetAll();

        return borrowings.Any(b => b.BookId == bookId && b.BorrowingDate <= DateTime.Now && b.ReturnDate is null); //or (b.ReturnDate.Value > DateTime.Now)
    }
}




