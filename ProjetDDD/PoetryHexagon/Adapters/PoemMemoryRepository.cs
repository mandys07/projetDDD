using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Adapters;

public class PoemMemoryRepository : IObtainPoems
{
    public string Poem = "This a poem";

    public string GetPoem()
    {
        return Poem;
    }
}
