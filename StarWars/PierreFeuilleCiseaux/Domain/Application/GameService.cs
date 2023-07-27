using PierreFeuilleCiseaux.Domain.Entities;

namespace PierreFeuilleCiseaux.Domain.Services;

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
