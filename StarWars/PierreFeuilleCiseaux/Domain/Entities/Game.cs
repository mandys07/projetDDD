namespace PierreFeuilleCiseaux.Domain.Entities;

public class Game
{
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public int Rounds { get; set; }
    public Player? Winner { get; set; }

    public Game(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
        Rounds = 0;
        Winner = null;
    }

    public string Play()
    {
        while(Winner is null)
        {
            Rounds++;
            Console.WriteLine($"Round {Rounds} : ");
            PlayRound(Player1, Player2);
            
            if (Player1.NbRoundsWon > 1)
            {
                Winner = Player1;
            }

            if (Player2.NbRoundsWon > 1)
            {
                Winner = Player2;
            }
        }

        return DisplayWinner();
    }

    public Player? PlayRound(Player player1, Player player2)
    {
        var round = new Round(player1, player2);
        return round.Play();
    }

    public string DisplayWinner()
    {
        return $"The player {Winner!.Name} won !";
    }
}
