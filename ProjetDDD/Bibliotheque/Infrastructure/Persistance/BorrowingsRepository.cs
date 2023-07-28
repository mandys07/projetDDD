using Bibliotheque.Domain.Entities;
using System.Reflection;

namespace Bibliotheque.Infrastructure.Persistance;

public class BorrowingsRepository : IRepository<Borrowing>
{
    private readonly string _borrowingsFile;

    public BorrowingsRepository(string borrowingsFile)
    {
        var assembly = Assembly.GetExecutingAssembly();
        _borrowingsFile = $"{assembly.GetName().Name}.Borrowings.txt";
    }

    public List<Borrowing> GetAll()
    {
        List<Borrowing> borrowings = new List<Borrowing>();

        if (File.Exists(_borrowingsFile))
        {
            var lignes = File.ReadAllLines(_borrowingsFile);

            foreach (var ligne in lignes)
            {
                var values = ligne.Split(';');

                if (values.Length == 5)
                {
                    Guid id;
                    Guid.TryParse(values[0], out id);

                    Guid bookId;
                    Guid.TryParse(values[1], out bookId);

                    Guid memberId;
                    Guid.TryParse(values[2], out memberId);

                    DateTime borrowingDate;
                    DateTime.TryParse(values[3], out borrowingDate);

                    DateTime returnDate;
                    DateTime.TryParse(values[4], out returnDate);

                    var borrowing = new Borrowing
                    {
                        Id = id,
                        BookId = bookId,
                        MemberId = memberId,
                        BorrowingDate = borrowingDate,
                        ReturnDate = returnDate
                    };
                    borrowings.Add(borrowing);
                }
            }
        }
        return borrowings;
    }

    public Borrowing GetById(Guid id)
    {
        List<Borrowing> borrowings = GetAll();
        var borrowing = borrowings.FirstOrDefault(b => b.Id == id);

        if (borrowing is null)
            throw new Exception("Not found");

        return borrowing;
    }

    public void Insert(Borrowing borrowing)
    {
        using (StreamWriter writer = new StreamWriter(_borrowingsFile))
        {
            var returnDate = borrowing.ReturnDate.HasValue ? borrowing.ReturnDate.Value.ToShortDateString() : "Not specified";

            string ligne = $"{borrowing.Id};{borrowing.BookId};{borrowing.MemberId};{borrowing.BorrowingDate.ToShortDateString()};{returnDate}";
            writer.WriteLine(ligne);
        }
    }

    public void Update(Borrowing borrowing)
    {
        Borrowing entity = GetById(borrowing.Id);

        if (entity != null)
        {
            entity.BookId = borrowing.BookId;
            entity.MemberId = borrowing.MemberId;
            entity.BorrowingDate = borrowing.BorrowingDate;
            entity.ReturnDate = borrowing.ReturnDate;

            Insert(entity);
        }
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
