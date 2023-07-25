using StarWars.Interfaces;

namespace StarWars.Entities;

public abstract class VehicleBase : IVehicle
{
    public string Start()
    {
        return "Start";
    }

    public string Stop()
    {
        return "Stop";
    }

    public abstract string Embark();
}