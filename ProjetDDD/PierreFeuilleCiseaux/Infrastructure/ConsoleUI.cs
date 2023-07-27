using PierreFeuilleCiseaux.Application;

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
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("------------------------- GAME ON -----------------------");
        GameService.PlayGame();
    }
}
