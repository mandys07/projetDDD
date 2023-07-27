using PierreFeuilleCiseaux.Domain.Enum;
using System;

namespace PierreFeuilleCiseaux.Domain.Entities;

public class Round
{
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Sign? Sign1 { get; set; }
    public Sign? Sign2 { get; set; }

    public Round(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
        Sign1 = null;
        Sign2 = null;
    }

    public Player? Play()
    {
        Random random = new Random();
        Sign1 = (Sign)random.Next(1, 4);
        Console.WriteLine($"{Player1.Name} play {Sign1.Value.ToString()}");
        Sign2 = (Sign)random.Next(1, 4);
        Console.WriteLine($"{Player2.Name} play {Sign2.Value.ToString()}");

        if (Sign1 == Sign2)
        {
            Console.WriteLine($"--> Equal");
            return null;
        }

        if (Sign1 == Sign.Rock && Sign2 == Sign.Scissors ||
            Sign1 == Sign.Paper && Sign2 == Sign.Rock    ||
            Sign1 == Sign.Scissors && Sign2 == Sign.Paper)
        {
            Console.WriteLine($"--> {Player1.Name}");
            Player1.NbRoundsWon++;
            return Player1;
        }
        else
        {
            Console.WriteLine($"--> {Player2.Name}");
            Player2.NbRoundsWon++;
            return Player2;
        }          
    }
}
