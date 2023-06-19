using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace SuperSimuladorDeComeiaComDrawn
{
    [Serializable]
    public class Hive
    {
        public Bee.BeeMessage SendMessage = null;
        private const int InitialBees = 10;
        private const int MaxNumOfBees = 1000;
        private const int MinHoneyToNewBee = 4;
        private const double InitialHoney = 3.5;
        private const double NectarHoneyRatio = .30;
        public static double MaxHoneyStoreble => 15;
        
        public double Honey { get; private set; }
        
        Dictionary<string,Point> locations;
        
        private int beeCount = 0;

        
        private World world;

        

        public Hive(World world,Bee.BeeMessage SendMessage)
        {
            this.SendMessage = SendMessage;
            this.world = world;
            Honey = InitialHoney;          
            InitializerLocation();
            Random random = new Random();
            for (int i = 0; i < InitialBees; i++)
            AddBee(random);
        }

        private void InitializerLocation()
        {
            locations = new Dictionary<string, Point>();
            locations.Add("Entrace",new Point(751, 71));
            locations.Add("Nursery", new Point(200, 455));
            locations.Add("HoneyFactory", new Point(410, 245));
            locations.Add("Exit", new Point(455, 565));
        }

        public bool AddHoney(double nectar)
        {
            double honeyToAdd = nectar * NectarHoneyRatio;//Primeiro, determinamos quanto de mel pode resultar de converter uma quantidade de néctar...
            if(honeyToAdd + Honey > MaxHoneyStoreble) //...e então vemos se há espaço na colméia para armazenar essa quantidade
                return false;
            Honey += honeyToAdd;
            return true;
        }

        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey) 
                return false;
            else
            {
                Honey -= amount;
                return true;
            }
        }

        public void AddBee(Random random)
        {
            beeCount++;
                int rX = random.Next(100) - 50; //Isso cria um ponto dentro de 50 unidades tanto na...
                int rY = random.Next(100) - 50;//...direção X quanto na Y da posição do berçario

                Point startPoint = new Point(locations["Nursery"].X + rX,
                                        locations["Nursery"].Y + rY);

                Bee newBee = new Bee(beeCount, startPoint, world, this);
                newBee.SendMessage += this.SendMessage;
                world.Bees.Add(newBee);
            
        }

        public void Go(Random random)
        {
            if (world.Bees.Count < MaxNumOfBees
                &&Honey > MinHoneyToNewBee // cria uma nova abelha sempre quando tem o minimo de mel necessario.
                && random.Next(10) == 1) // Gera-se um número aleatório entre 0 e 9. Se ele for 1, cria-se a abelha
                AddBee(random);
        }
        
        public Point GetLocation(string location)
        {
            if (locations.ContainsKey(location))
                return locations[location];     //carai, muito experto
            else
                throw new ArgumentException($"O local {location} não existe");
        }

    }
}
