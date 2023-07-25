namespace StarWars.Entities
{
    public class Repulsorcraft : Vehicle
    {
        public Repulsorcraft() : base()
        {
            CapacityMaxCharger = 100;
            CapacityCharger = 100;
        }

        public override void Reload()
        {
            System.Threading.Thread.Sleep(5000);
            CapacityCharger = CapacityMaxCharger;
        }

        public override void Shoot()
        {
            if (CapacityCharger == 0)
            {
                throw new Exception("The charger is empty, you have to reload");
            }

            CapacityCharger -= 2;
        }
    }
}