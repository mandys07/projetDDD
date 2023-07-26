using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Controller;

public class PoemController
{
    private readonly IWritePoem writePoemUseCase;

    public PoemController(IWritePoem writePoemUseCase)
    {
        this.writePoemUseCase = writePoemUseCase;
    }

    public void Execute()
    {
        //Get poem
        string poemContent = "This is a poem";

        writePoemUseCase.WritePoem(poemContent);
    }
}
