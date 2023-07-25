using System;

namespace StarWars.Entities;

public class StarshipFactory
{
    public Starship Create(string type)
    {
        Starship starship = null;

        switch (type.ToLower())
        {
            case "corvette":
                starship = new CorvetteStarship();
                break;
            case "destroyer":
                starship = new StarDestroyerStarship();
                break;
            default:
                throw new ArgumentException("Type de starship inconnu.");
        }

        return starship;
    }
}
