using StarWars.Entities;

namespace Test;

[TestClass]
public class StarWarsTest
{
    [TestMethod]
    public void TestVehiculeStart()
    {
        Repulsorcraft repulsorcraft = new Repulsorcraft();
        var result = repulsorcraft.Start();
        Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void TestVehiculeStop()
    {
        Repulsorcraft repulsorcraft = new Repulsorcraft();
        var result = repulsorcraft.Stop();
        Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void TestVehiculeEmbark()
    {
        Repulsorcraft repulsorcraft = new Repulsorcraft();
        var result = repulsorcraft.Embark();
        Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void TestVehiculeShoot()
    {
        Starship starship = new Starship();
        var result = starship.Shoot();
        Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void TestVehiculeReload()
    {
        Starship starship = new Starship();
        var result = starship.Reload();
        Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void TestCorvetteStarshipCreate()
    {
        StarshipFactory factory = new StarshipFactory();
        var result = factory.Create("corvette");
        Assert.IsInstanceOfType(result, typeof(CorvetteStarship));
    }

    [TestMethod]
    public void TestDestroyerStarshipCreate()
    {
        StarshipFactory factory = new StarshipFactory();
        var result = factory.Create("destroyer");
        Assert.IsInstanceOfType(result, typeof(StarDestroyerStarship));
    }

    [TestMethod]
    public void TestStarshipCountPassengers()
    {
        CorvetteStarship starship = new CorvetteStarship();
        var result = starship.CountPassengers();
        Assert.IsInstanceOfType(result, typeof(int));
    }

    [TestMethod]
    public void TestStarshipAttack()
    {
        CorvetteStarship corvette = new CorvetteStarship();
        StarDestroyerStarship starship = new StarDestroyerStarship();
        var result = starship.Attack(corvette);
        Assert.IsInstanceOfType(result, typeof(string));
    }
}