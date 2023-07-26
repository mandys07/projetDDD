namespace StarWars.Application;

public interface IStarshipCommandBus<T>
{
    Task<T> Execute();
}
