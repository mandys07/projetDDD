using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Adapters;

public class WritePoemUseCase : IWritePoem
{
    private readonly IObtainPoems poemReader;
    private readonly IWriteLines writer;

    public WritePoemUseCase(IObtainPoems poemReader, IWriteLines writer)
    {
        this.poemReader = poemReader;
        this.writer = writer;
    }

    public void WritePoem(string poemContent)
    {
        string poem = poemReader.GetPoem();
        writer.WriteLine(poemContent);
    }
}
