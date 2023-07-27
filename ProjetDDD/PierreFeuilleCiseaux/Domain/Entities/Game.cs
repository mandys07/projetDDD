using PierreFeuilleCiseaux.Domain.Enum;

namespace PierreFeuilleCiseaux.Domain.Entities;

public class Game
{
    public Player Player { get; set; }
    public Player Computer { get; set; }
    public List<Round> Rounds { get; set; }
    public Player? Winner { get; set; }

    public Game(Player player)
    {
        Player = player;
        Computer = new Player("Computer");
        Rounds = new List<Round>();
        Winner = null;
    }

    public void Init()
    {
        Play();
        ReplayOrFinish();
    }

    public string Play()
    {
        while(Winner is null)
        {
            PlayRound(Player, Computer);
            Console.WriteLine($"Round {Rounds.Count} : ");
            Console.WriteLine($"{Rounds[Rounds.Count - 1].Player.Name} choose {Rounds[Rounds.Count - 1].SignPlayer}");
            Console.WriteLine($"{Rounds[Rounds.Count - 1].Computer.Name} choose {Rounds[Rounds.Count - 1].SignComputer}");
            Console.WriteLine($"--> {Rounds[Rounds.Count - 1].Winner!.Name} won");

            if (Player.NbRoundsWon > 1)
            {
                Winner = Player;
            }

            if (Computer.NbRoundsWon > 1)
            {
                Winner = Computer;
            }
        }

        return DisplayWinner();
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

    public void PlayRound(Player player, Player computer)
    {
        var round = new Round(player, computer);
        round.Compare();
        Rounds.Add(round);
    }

    public string DisplayWinner()
    {
        return $"The player {Winner!.Name} won the game !";
    }

    public void DisplayHistorical()
    {
        Console.WriteLine($"------------------ HISTORICAL GAME ROUNDS --------------");
        for (var i = 0; i < Rounds.Count; i++)
        {
            Console.WriteLine($"Round {i} : ");
            Console.WriteLine($"{Rounds[i].Player.Name} choose {Rounds[i].SignPlayer}");
            Console.WriteLine($"{Rounds[i].Computer.Name} choose {Rounds[i].SignComputer}");
            Console.WriteLine($"--> {Rounds[i].Winner!.Name} won");
        }
        Console.WriteLine($"The player {Winner!.Name} won the game !");
    }

    public void Replay(Player player)
    {
        Game game = new Game(player);
        game.Init();
    }
}
