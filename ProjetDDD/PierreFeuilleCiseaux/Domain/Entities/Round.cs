using PierreFeuilleCiseaux.Domain.Enum;
using System;

namespace PierreFeuilleCiseaux.Domain.Entities;

public class Round
{
    public Player Player { get; set; }
    public Player Computer { get; set; }
    public List<string> Historical { get; set; }

    public Round(Player player, Player computer)
    {
        Player = player;
        Computer = computer;
        Historical= new List<string>();
    }

    public List<string> Compare()
    {
        var signPlayer = PlayerChoose();
        var signComputer = ComputerChoose();

        Historical.Add($"{Player.Name} choose {signPlayer.ToString()}");
        Historical.Add($"{Computer.Name} choose {signComputer.ToString()}");

        Console.WriteLine($"{Player.Name} choose {signPlayer.ToString()}");
        Console.WriteLine($"{Computer.Name} choose {signComputer.ToString()}");

        if (signPlayer == signComputer)
        {
            Historical.Add($"--> Equal");
            Console.WriteLine($"--> Equal");
            return Historical;
        }

        if (signPlayer == Sign.Rock && signComputer == Sign.Scissors ||
            signPlayer == Sign.Paper && signComputer == Sign.Rock    ||
            signPlayer == Sign.Scissors && signComputer == Sign.Paper)
        {
            Historical.Add($"--> {Player.Name}");
            Console.WriteLine($"--> {Player.Name}");
            Player.NbRoundsWon++;
        }
        else
        {
            Historical.Add($"--> {Computer.Name}");
            Console.WriteLine($"--> {Computer.Name}");
            Computer.NbRoundsWon++;
        }      
        
        return Historical;
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
