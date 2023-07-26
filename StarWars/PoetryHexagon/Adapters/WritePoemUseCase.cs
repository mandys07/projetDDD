using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Adapters;

public class WritePoemUseCase : IWritePoem
{
    private readonly IObtainPoems _poemReader;
    private readonly IWriteLines _writer;

    public WritePoemUseCase(IObtainPoems poemReader, IWriteLines writer)
    {
        _poemReader = poemReader;
        _writer = writer;
    }

    public void WritePoem(string poemContent)
    {
        string poem = _poemReader.GetPoem();
        _writer.WriteLine(poemContent);
    }
}
