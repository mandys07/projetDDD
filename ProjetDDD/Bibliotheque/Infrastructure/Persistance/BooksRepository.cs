using Bibliotheque.Domain.Entities;

namespace Bibliotheque.Infrastructure.Persistance;

public class BooksRepository : IRepository<Book>
{
    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public Book GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Book entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Book entity)
    {
        throw new NotImplementedException();
    }
}
