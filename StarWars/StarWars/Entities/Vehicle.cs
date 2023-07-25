using StarWars.Interfaces;

namespace StarWars.Entities
{
    public abstract class Vehicle : IVehicle
    {
        public bool IsWorking { get; set; }
        public int CapacityMaxCharger { get; set; }
        public int CapacityCharger { get; set; }

        public Vehicle()
        {
            IsWorking = false;
        }

        public void Start()
        {
            IsWorking = true;
        }

        public void Stop()
        {
            IsWorking = false;
        }

        public abstract void Shoot();
        public abstract void Reload();
    }
}