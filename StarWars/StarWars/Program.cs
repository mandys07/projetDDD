using StarWars.Entities;
using StarWars.Interfaces;

namespace StarWars;
class Program
{
    static void Main()
    {
        IVehicle vehicle1 = new Starships();
        Pilot pilot = new Pilot(vehicle1);

        Console.WriteLine($"Véhicule de type : {vehicle1.GetType()}");
        Console.WriteLine($"Etat : {vehicle1.IsWorking}");
        Console.WriteLine($"Capacité de chargement max : {vehicle1.CapacityMaxCharger}");
        Console.WriteLine($"Capacité de chargement actuel : {vehicle1.CapacityCharger}");


    }
}
