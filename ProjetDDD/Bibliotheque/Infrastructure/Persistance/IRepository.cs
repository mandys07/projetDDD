namespace Bibliotheque.Infrastructure.Persistance;

public interface IRepository<T>
{
    void Insert(T entity);
    T GetById(Guid id);
    void Update(T entity);
    void Delete(Guid id);
    List<T> GetAll();
}
