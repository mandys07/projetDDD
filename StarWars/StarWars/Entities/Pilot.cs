using StarWars.Interfaces;

namespace StarWars.Entities;

public class Pilot
{
    private readonly IVehicle _vehicle;

    public Pilot(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }

    public void Start()
    {
        _vehicle.Start();
    }

    public void Stop()
    {
        _vehicle.Start();
    }

    public void Embark()
    {
        _vehicle.Embark();
    }
}