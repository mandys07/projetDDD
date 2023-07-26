using StarWars.Entities;
using StarWars.Services;

namespace StarWars.Application;

public class FetchAllStarshipsCommandHandler : IHandler<string>
{
    public void Handle(string data)
    {
        foreach (var starship in data)
        {
            //Console.WriteLine($"Name: {starship.Name}, Model: {starship.Model}, Manufacturer: {starship.Manufacturer}");
        }
    }
}