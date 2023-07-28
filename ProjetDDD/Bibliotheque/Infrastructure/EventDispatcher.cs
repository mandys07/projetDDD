using Bibliotheque.Domain.Entities;
using Bibliotheque.Domain.Events;
using Bibliotheque.Infrastructure.Persistance;

namespace Bibliotheque.Infrastructure;

public interface IEventDispatcher
{
    void Dispatch<TEvent>(TEvent @event);
}

public class EventDispatcher : IEventDispatcher
{
    private readonly BorrowingsRepository _borrowingsRepository;

    public EventDispatcher(BorrowingsRepository borrowingsRepository)
    {
        _borrowingsRepository = borrowingsRepository;
    }

    public void Dispatch<TEvent>(TEvent @event)
    {
        if (@event is BookBorrowingEvent bookBorrowingEvent)
        {
            var borrowing = new Borrowing
            {
                BookId = bookBorrowingEvent.BookId,
                MemberId = bookBorrowingEvent.MemberId,
                BorrowingDate = bookBorrowingEvent.BorrowingDate,
                ReturnDate = null
            };

            _borrowingsRepository.Insert(borrowing);
        }
        else
        {
            throw new NotSupportedException($"Event not supported : {typeof(TEvent).Name}");
        }
    }
}
