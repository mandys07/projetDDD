namespace StarWars.Entities
{
    public class Starships : Vehicle
    {
        public Starships() : base()
        {
            CapacityMaxCharger = 25;
            CapacityCharger = 25;
        }

        public override void Reload()
        {
            System.Threading.Thread.Sleep(2000);
            CapacityCharger = CapacityMaxCharger;
        }

        public override void Shoot()
        {
            if (CapacityCharger == 0)
            {
                throw new Exception("The charger is empty, you have to reload");
            }

            CapacityCharger--;
        }
    }
}