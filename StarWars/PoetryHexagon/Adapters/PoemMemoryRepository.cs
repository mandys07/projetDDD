using PoetryHexagon.Interfaces;

namespace PoetryHexagon.Adapters;

public class PoemMemoryRepository : IObtainPoems
{
    private string poem = "This a poem";

    public string GetPoem()
    {
        return poem;
    }
}
