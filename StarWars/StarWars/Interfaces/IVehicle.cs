namespace StarWars.Interfaces
{
    public interface IVehicle
    {
        bool IsWorking { get; set; }
        int CapacityMaxCharger { get; set; }
        int CapacityCharger { get; set; }
        void Start();
        void Stop();
        void Reload();
        void Shoot();
    }
}