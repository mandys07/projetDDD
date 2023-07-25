using StarWars.Interfaces;

namespace StarWars.Entities;

public abstract class VehiculeShooter : IVehicle, ICanShoot
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

    public abstract string Shoot();

    public string Reload()
    {
        return "Reload";
    }
}
