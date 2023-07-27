namespace StarWars.Application;

public interface IHandler<T>
{
    void Handle(T data);
}
