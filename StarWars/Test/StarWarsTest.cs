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
}