using StarWars.Entities;

namespace StarWars.Application;

public class StarshipDTO
{
    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
}

public static class StarshipMapper
{
    public static StarshipDTO MapToStarship(dynamic starshipData)
    {
        return new StarshipDTO
        {
            Name = starshipData.name,
            Model = starshipData.model,
            Manufacturer = starshipData.manufacturer
        };
    }
}
