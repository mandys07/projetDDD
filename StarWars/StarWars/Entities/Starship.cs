using StarWars.Interfaces;

namespace StarWars.Entities;

public class Starship : VehiculeShooter
{
    public override string Embark()
    {
        return "Embarquement 2 personnes";
    }

    public override string Shoot()
    {
        return "Tir en rafale";
    }
}