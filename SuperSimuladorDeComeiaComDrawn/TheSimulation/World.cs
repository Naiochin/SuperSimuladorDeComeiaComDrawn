using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SuperSimuladorDeComeiaComDrawn
{
    [Serializable]
    public class World
    {
        private const double NectarHarvestedPerNewFlower = 50.0;
        private const int FieldMinX = 15;
        private const int FieldMinY = 300;
        private const int FieldMaxX = 755;
        private const int FieldMaxY = 370;

        public Hive Hive;

        public List<Wasp> Wasps;
        public List<Bee> Bees;

        
        public List<Flower> Flowers;

        public World(Bee.BeeMessage messageSender)
        {
            Bees = new List<Bee>();
            Flowers = new List<Flower>();
            Wasps = new List<Wasp>(); 
            Hive = new Hive(this,messageSender);
            Random random = new Random();
            for (int i = 0; i < 10; i++)
                AddFlower(random);
            


        }

       

        public void Go(Random random)
        {
            Hive.Go(random);
            for(int i = Bees.Count - 1; i >= 0; i--)
            {
                Bee bee = Bees[i];
                bee.Go(random);
                if (bee.CurrentState == BeeState.Retired)
                    Bees.Remove(bee);
            }
            double totalNectarHarvested = 0;
            for(int i = Flowers.Count - 1; i >= 0; i--)
            {
                Flower flower = Flowers[i];
                flower.Go();
                totalNectarHarvested += flower.NectarHarvested;
                if (!flower.Alive)
                    Flowers.Remove(flower);
            }
            if(totalNectarHarvested > NectarHarvestedPerNewFlower)
            {
                    foreach (var flower in Flowers)
                        flower.NectarHarvested = 0;
                    AddFlower(random);
                
            }
            AddWasp(random);
            for (int i = Wasps.Count - 1; i >= 0; i--)
            {
                var wasp = Wasps[i];
                wasp.Go(random);
            }
        }

        private void AddFlower(Random random)
        {
            //x800; y169
            Point location = new Point(random.Next(FieldMinX, FieldMaxX),
                                        random.Next(FieldMinY, FieldMaxY));
            Flower newFlower = new Flower(location);
            Flowers.Add(newFlower);
        }

        
        int NextMinNumOflowersToMakeWasp = 0;
        private void AddWasp(Random random)
        {
            if (Flowers.Count == (NextMinNumOflowersToMakeWasp + 10))
            {
                Wasps.Add(new Wasp(Hive, this,
                    new Point(-random.Next(100), -random.Next(100))));
                NextMinNumOflowersToMakeWasp += 10;
            }
        }
    }
}
