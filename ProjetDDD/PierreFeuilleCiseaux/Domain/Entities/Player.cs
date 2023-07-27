namespace PierreFeuilleCiseaux.Domain.Entities;

public class Player
{
    public string Name { get; set; }
    public int NbRoundsWon { get; set; }

    public Player(string name)
    {
        Name = name;
        NbRoundsWon = 0;
    }
}
