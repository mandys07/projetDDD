namespace StarWars.Entities;

public class CorvetteStarship : Starship
{
    public int CountPassengers()
    {
        Random random = new Random();
        return random.Next(0, 3);
    }
}
