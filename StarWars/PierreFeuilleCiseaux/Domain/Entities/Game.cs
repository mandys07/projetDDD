using PierreFeuilleCiseaux.Domain.Enum;

namespace PierreFeuilleCiseaux.Domain.Entities;

public class Game
{
    public Player Player { get; set; }
    public Player Computer { get; set; }
    public int NbRounds { get; set; }
    public Player? Winner { get; set; }
    public List<string> Historical { get; set; }

    public Game(Player player)
    {
        Player = player;
        Computer = new Player("Computer");
        NbRounds = 0;
        Winner = null;
        Historical = new List<string>
        {
            "---------------------------------------------------------",
            "Rounds historical :"
        };
    }

    public void Init()
    {
        Play();
        ReplayOrFinish();
    }

    public void Play()
    {
        if(NbRounds == 0)
        {
            Console.WriteLine("------------------------- GAME ON -----------------------");
        }

        while(Winner is null)
        {
            NbRounds++;
            Historical.Add($"Round {NbRounds} : ");
            Historical.AddRange(PlayRound(Player, Computer));
            
            if (Player.NbRoundsWon > 1)
            {
                Winner = Player;
            }

            if (Computer.NbRoundsWon > 1)
            {
                Winner = Computer;
            }
        }

        Historical.Add($"The player {Winner!.Name} won the game !");
        Console.WriteLine(DisplayWinner());
    }

    public void ReplayOrFinish()
    {
        Console.WriteLine("Choose 1 to play again or 2 to display historical rounds :");
        string userInput = Console.ReadLine();
        int userChoice = int.Parse(userInput);

        if(userChoice == 1)
            Replay(Player);

        DisplayHistorical();
    }

    public List<string> PlayRound(Player player1, Player player2)
    {
        var round = new Round(player1, player2);
        return round.Compare();
    }

    public string DisplayWinner()
    {
        return $"The player {Winner!.Name} won the game !";
    }

    public void DisplayHistorical()
    {
        foreach(var roundInfo in Historical)
        {
            Console.WriteLine(roundInfo);
        }
    }

    public void Replay(Player player)
    {
        Game game = new Game(player);
        game.Play();
    }
}
