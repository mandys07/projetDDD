namespace Bibliotheque.Domain.Events;

public class BookBorrowingEvent
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime BorrowingDate { get; set; }
}
