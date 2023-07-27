using PierreFeuilleCiseaux.Domain.Entities;

namespace PierreFeuilleCiseaux.Application;

public class GameService
{
    public Game Game;

    public GameService(Game game)
    {
        Game = game;
    }

    public void PlayGame()
    {
        Game.Init();
    }
}
