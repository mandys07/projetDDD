namespace StarWars.Entities;

public class StarDestroyerStarship : Starship
{
    public string Attack(Starship target)
    {
        return $"{target.GetType()} attacked";
    }
}
