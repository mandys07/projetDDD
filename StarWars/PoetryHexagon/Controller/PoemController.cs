using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Controller;

public class PoemController
{
    private readonly IWritePoem _writePoemUseCase;

    public PoemController(IWritePoem writePoemUseCase)
    {
        _writePoemUseCase = writePoemUseCase;
    }

    public void Execute()
    {
        //Get poem
        string poemContent = "This is a poem";

        _writePoemUseCase.WritePoem(poemContent);
    }
}
