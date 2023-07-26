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

    public void Play()
    {
        if (Player1.NbRoundsWon > 1)
            Winner = Player1;
            //break
        if (Player2.NbRoundsWon > 1)
            Winner = Player2;
            
        PlayRound(Player1, Player2);
    }

    public Player? PlayRound(Player player1, Player player2)
    {
        var round = new Round(player1, player2);
        return round.Play();
    }

    public string DisplayWinner(Player player)
    {
        return $"The player {player.Name} won !";
    }
}
