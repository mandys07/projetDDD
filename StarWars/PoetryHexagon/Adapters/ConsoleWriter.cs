using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Adapters;

public class ConsoleWriter : IWriteLines
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}
