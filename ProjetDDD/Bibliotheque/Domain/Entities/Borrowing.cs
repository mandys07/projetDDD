namespace Bibliotheque.Domain.Entities;

public class Borrowing
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book? Book { get; set; }
    public Guid MemberId { get; set; }
    public Member? Member { get; set; }
    public DateTime BorrowingDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
