using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SuperSimuladorDeComeiaComDrawn
{
    public class Wasp
    {
        private Timer TimerToAttack = new Timer();

        private const int MoveRate = 3;
        private const int life = 10;

        private Point location;
        public Point Location => location;

        private Point HivePosition = new Point(710, 46);
        public int Life { get => life; }

        private bool alive;
        
        private Hive hive;
        private World world;

        public Wasp(Hive hive, World world,Point InialLocation)
        {
            this.hive = hive;
            this.world = world;
            this.location = InialLocation;
            TimerToAttack.Tick += TimerToAttack_Tick;
            TimerToAttack.Interval = 2000;
            
        }


        public void Go(Random random)
        {
            if (MoveTowardsLocation(HivePosition))
            {
                TimerToAttack.Start();
            }          
              
        }
        bool primary = true;
        private void TimerToAttack_Tick(object sender,EventArgs e)
        {
            AttackHive(10);
        }

        public void AttackHive(int damage)
        {
            if (primary)
            {
                MoveTowardsLocation(new(HivePosition.X + 20, HivePosition.Y + 20));
                primary = false;
                return;
            }
            else {
                primary = true;
                MoveTowardsLocation(HivePosition);
                    }



        }

        private bool MoveTowardsLocation(Point destination)
        {
            if (destination != Point.Empty)
            {
                if (Math.Abs(destination.X - location.X) <= MoveRate && //O método começa determinando se já estamos
                    Math.Abs(destination.Y - location.Y) <= MoveRate)   //no destino ou mais próximos dele do que MoveRate(Taxa de deslocamento)
                    return true;

                /*O codigo abaixo verifica, se não estamos pertos o suficiente, movemo-nos na direção do 
                  destino uma distância igual à taxa de deslocamento */
                for (int i = 0; i < MoveRate; i++)
                {
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
}
