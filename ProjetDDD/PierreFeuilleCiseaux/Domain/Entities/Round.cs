using PierreFeuilleCiseaux.Domain.Enum;
using System;

namespace PierreFeuilleCiseaux.Domain.Entities;

public class Round
{
    public Player Player { get; set; }
    public Player Computer { get; set; }
    public Sign? SignPlayer { get; set; }
    public Sign? SignComputer { get; set; }
    public Player? Winner { get; set; }

    public Round(Player player, Player computer)
    {
        Player = player;
        Computer = computer;
        SignPlayer = null;
        SignComputer = null;
        Winner = null;
    }

    public void Compare()
    {
        SignPlayer = PlayerChoose();
        SignComputer = ComputerChoose();

        if (SignPlayer == SignComputer)
        {
            Winner = null;
        }

        if (SignPlayer == Sign.Rock && SignComputer == Sign.Scissors ||
            SignPlayer == Sign.Paper && SignComputer == Sign.Rock    ||
            SignPlayer == Sign.Scissors && SignComputer == Sign.Paper)
        {
            Player.NbRoundsWon++;
            Winner = Player;
        }
        else
        {
            Computer.NbRoundsWon++;
            Winner = Computer;
        }      
    }

    public Sign PlayerChoose()
    {
        while (true)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Please choose a sign :");
            Console.WriteLine("(Note : 1 - Rock | 2 - Paper | 3 - Scissors)");
            string userInput = Console.ReadLine();

            if (IsNumber(userInput))
            {
                int signId = int.Parse(userInput);

                if (signId >= 1 && signId <= 3)
                {
                    return (Sign)signId;
                }
            }

            Console.WriteLine("The entry is not valid. Try again !");
        }
    }

    public Sign ComputerChoose()
    {
        Random random = new Random();
        return (Sign)random.Next(1, 4);
    }

    static bool IsNumber(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}
