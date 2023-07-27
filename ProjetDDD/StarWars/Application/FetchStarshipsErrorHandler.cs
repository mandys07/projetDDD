namespace StarWars.Application;

public class FetchStarshipsErrorHandler : IHandler<Exception>
{
    public void Handle(Exception ex)
    {
        Console.WriteLine($"Error executing command: {ex.Message}");
    }
}