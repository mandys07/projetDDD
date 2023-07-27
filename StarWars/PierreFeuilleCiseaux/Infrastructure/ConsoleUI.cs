using PierreFeuilleCiseaux.Domain.Services;

namespace PierreFeuilleCiseaux.Infrastructure;

public class ConsoleUI
{
    public GameService GameService;

    public ConsoleUI(GameService gameService)
    {
        GameService = gameService;
    }

    public void StartGame()
    {
        Console.WriteLine("------------------------- GAME ON -----------------------");
        GameService.PlayGame();
    }
}
