namespace Bibliotheque.Infrastructure;

public interface IEventDispatcher
{
    void Dispatch<TEvent>(TEvent @event);
}
