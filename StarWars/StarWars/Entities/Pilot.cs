using StarWars.Interfaces;

namespace StarWars.Entities
{
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
            _vehicle.Stop();
        }

        public void Shoot()
        {
            _vehicle.Shoot();
        }

        public void Reload()
        {
            _vehicle.Reload();
        }
    }
}