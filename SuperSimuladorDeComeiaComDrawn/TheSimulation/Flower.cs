using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SuperSimuladorDeComeiaComDrawn
{
    [Serializable]
    public class Flower
    {
        #region Consts
        public const int LifeSpanMin = 15000;
        public const int LifeSpanMax = 20000;
        public const double InitialNectar = 1.5;
        public const double MaxNectar = 5;
        public const double NectarAddedPerTurn = 0.01;
        public const double NectarGatheredPerTurn = 0.5;
        #endregion
        [NonSerialized]
        private Random random;
       
        private Point location;
        
        private int age;
        
        private bool alive;
       
        private double nectar;
       
        private double nectarHarvested;
        
        private int lifeSpan;
        #region Getters and Setters
        public Point Location { get => location; }
        public int Age { get => age;}
        public bool Alive { get => alive; }
        public double Nectar { get => nectar;}
        public double NectarHarvested { get => nectarHarvested; set => nectarHarvested = value; }
        #endregion
        
        
        public Flower(Point location)
        {
            random = new Random();
            this.location = location;
            alive = true;
            age = 0;
            nectar = InitialNectar;
            nectarHarvested = 0;
            
            lifeSpan = random.Next(LifeSpanMin, LifeSpanMax + 1);//Dar um tempo de vida aleatorio para a flor
            
            
        }

        public double HaverstNectar()
        {
            if (nectarHarvested > nectar)
                return 0;
            else
            {
                nectar -= NectarGatheredPerTurn;
                nectarHarvested += NectarGatheredPerTurn;
                return NectarGatheredPerTurn;
            }
                
        }
        /** 
            Como parte do simulador, o método Go() será chamado cada quadro de tempo.
          Isso fará a flor envelhecer apenas uma pequena fração de cada vez conforme 
          o simulador for executando, essas pequenas frações vão se acumulando
          
         */
        public void Go()
        {
            age++;
            if (age > LifeSpanMax)
                alive = false;
            else
            {
                nectar += NectarAddedPerTurn;
                if (nectar > MaxNectar)
                    nectar = MaxNectar;
            }
        }
    }
}
