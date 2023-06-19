using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SuperSimuladorDeComeiaComDrawn
{
    [Serializable]
    public class Bee
    {
        public delegate void BeeMessage(int ID, string Message);
        public event BeeMessage SendMessage;
     
        public BeeState CurrentState { get; private set; }
        private const double HoneyConsumed = 0.3;
        private const int MoveRate = 3;
        private const double MinimumFlowerNectar = 1.5;
        private const int CareerSpan = 1000; //Top 10 piadas
  
        public int Age { get; private set; }
   
        public bool InsideHive { get; private set; }
        
        public double NectarCollected { get; private set; }
       
        private Point location;
        public Point Location => location;
       
        public int ID { get; private set; }
       
        private Flower destinationFlower;
        
        private Hive hive;
        
        private World world;

        public Bee(int id, Point InitialLocation,World world, Hive hive)
        {
            this.world = world;
            this.hive = hive;
            this.ID = id;
            Age = 0;
            this.location = InitialLocation;
            InsideHive = true;
            CurrentState = BeeState.Idle;
            destinationFlower = null;
            NectarCollected = 0;
        }
        
        public void Go(Random random)
        {
            Age++;
            BeeState oldState = CurrentState;
            switch (CurrentState)
            {              
                case BeeState.Idle:
                    if (Age > CareerSpan)
                    {
                        if (MoveTowardsLocation(hive.GetLocation("Nursery")))
                        CurrentState = BeeState.Retired;
                    }
                    else if (world.Flowers.Count > 0 // Ver se ainda existe flores 
                        && hive.ConsumeHoney(HoneyConsumed))
                    {// e então consume mel suficiente para a

                        Flower flower = world.Flowers[random.Next(world.Flowers.Count)];//retorna uma flor aleatoria, tanto viva quanto morta
                        if (flower.Nectar >= MinimumFlowerNectar && flower.Alive)//Verifica se a flor tem o minimo de nectar e se está viva
                        {
                            destinationFlower = flower;
                            CurrentState = BeeState.FlyingToFlower;
                        }
                    }
                        break;
                case BeeState.FlyingToFlower:
                    if (!world.Flowers.Contains(destinationFlower))//Verifica se a flor não morreu enquanto nos dirigíamos até ela
                        CurrentState = BeeState.ReturningToHive;
                    else if (InsideHive) // Ele estiver dentro da comeia 
                    {
                        if (MoveTowardsLocation(hive.GetLocation("Exit")))// ele se desloca até a saida
                        {
                            InsideHive = false;
                            location = hive.GetLocation("Entrace");
                        }
                    }
                    else if (MoveTowardsLocation(destinationFlower.Location))
                        CurrentState = BeeState.GatheringNectar;
                    break;

                case BeeState.GatheringNectar:
                    double nectar = destinationFlower.HaverstNectar();
                    if (nectar > 0)
                        NectarCollected += nectar;
                    else
                        CurrentState = BeeState.ReturningToHive;
                    break;

                case BeeState.ReturningToHive:
                    if (!InsideHive)
                    {
                        if (MoveTowardsLocation(hive.GetLocation("Entrace")))
                        {//Se chegamos à colméia, atualize nossa posição
                            InsideHive = true; // e assuma o status insideHive(dentro da colméia).
                            location = hive.GetLocation("Exit");
                        }
                    }
                    else if (MoveTowardsLocation(hive.GetLocation("HoneyFactory"))) //Se já estamos na colméia, vamos em direção a fabrica de mel
                        CurrentState = BeeState.MakingHoney;
                    break;

                case BeeState.MakingHoney:
                    if(NectarCollected < 0.5)
                    {
                        NectarCollected = 0;
                        CurrentState = BeeState.Idle;
                    }
                    else
                    {
                        if (hive.AddHoney(0.5))
                            NectarCollected -= 0.5;
                        else
                            NectarCollected = 0; //Ele praticamente vai jogar o nectar fora
                    }
                    break;

                case BeeState.Retired:
                    //Não pode fazer nada! Somos aposentados
                    break;
            }

            if (oldState != CurrentState && SendMessage != null)
                SendMessage(ID, CurrentState.ToString());
        }

        //Agora já sei porquê este metodo retorna bool
        //Ele é muito versatil
        private bool MoveTowardsLocation(Point destination)
        {
            if (destination != Point.Empty)
            {
                if (Math.Abs(destination.X - location.X) <= MoveRate && //O método começa determinando se já estamos
                    Math.Abs(destination.Y - location.Y) <= MoveRate)   //no destino ou mais próximos dele do que MoveRate(Taxa de deslocamento)
                    return true;

                /*O codigo abaixo verifica, se não estamos pertos o suficiente, movemo-nos na direção do 
                  destino uma distância igual à taxa de deslocamento */
                for (int i = 0; i < MoveRate; i++) { 
                if (destination.X > location.X)
                    location.X += 1;
                else if (destination.X < location.X)
                    location.X -= 1;

                if (destination.Y > location.Y)
                    location.Y += 1;
                else if (destination.Y < location.Y)
                    location.Y -= 1;
            }
               // Debug.WriteLine($"bee:{ID} location: {location.X} ; {location.Y}");
            }
            return false;
        }

    }

    public enum BeeState
    {
        Idle,
        FlyingToFlower,
        GatheringNectar,
        ReturningToHive,
        MakingHoney,
        Retired,
    }
}
