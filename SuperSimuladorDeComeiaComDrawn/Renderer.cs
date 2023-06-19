using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SuperSimuladorDeComeiaComDrawn
{
    public class Renderer
    {
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;
        private List<Flower> deadFlowers = new List<Flower>();
        private List<Bee> retiredBees = new List<Bee>();

        private Bitmap HiveInside;
        private Bitmap HiveOutside;
        private Bitmap Flower;

        private Bitmap[] BeeAnimationLarge;
        private Bitmap[] BeeAnimationSmall;

        public Renderer(World world, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = world;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
            Iniatilizer();
        }

        private void Iniatilizer()
        {
            HiveInside = ResizeImage(Properties.Resources.Hive__inside_,hiveForm.ClientRectangle.Width,hiveForm.ClientRectangle.Height);
            Flower = ResizeImage(Properties.Resources.Flower, 75, 75);
            HiveOutside = ResizeImage(Properties.Resources.Hive__outside_, 80, 85);
          
            BeeAnimationLarge = new Bitmap[5]
            {
                new (Properties.Resources.Bee_0000_Capa_1,40,40),
                new (Properties.Resources.Bee_0001_Capa_2,40,40),
                new (Properties.Resources.Bee_0002_Capa_3,40,40),
                new (Properties.Resources.Bee_0003_Capa_4,40,40),
                new (Properties.Resources.Bee_0004_Capa_5,40,40),
            };
            BeeAnimationSmall = new Bitmap[5]
            {
                new (Properties.Resources.Bee_0000_Capa_1,20,20),
                new (Properties.Resources.Bee_0001_Capa_2,20,20),
                new (Properties.Resources.Bee_0002_Capa_3,20,20),
                new (Properties.Resources.Bee_0003_Capa_4,20,20),
                new (Properties.Resources.Bee_0004_Capa_5,20,20),
            };
        }

        private int Cell = 0;
        private int Frame = 0;
        public void AnimateBees()
        {
            Frame++;
            if (Frame >= 5)
                Frame = 0;
            switch (Frame)
            {
                case 0: Cell = 3; break;
                case 1: Cell = 2; break;
                case 2: Cell = 1; break;
                case 3: Cell = 0; break;
                default: Cell = 3; break;
            }
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }
        
        public void PainHive(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue,hiveForm.ClientRectangle);
            g.DrawImageUnscaled(HiveInside,hiveForm.ClientRectangle);
            foreach(Bee bee in world.Bees)
            {
                if (bee.InsideHive)
                {
                    g.DrawImageUnscaled(BeeAnimationLarge[Cell],
                        bee.Location.X, bee.Location.Y);
                    g.DrawString(bee.ID.ToString(), new Font("Arial", 10.0f, FontStyle.Italic), Brushes.Red,
                        new Point(bee.Location.X, bee.Location.Y));
                }
            }

        }

        public void PaintField(Graphics g)
        {
            using (Pen brownPen = new Pen(Color.Brown, 11.0f))
            {
                g.FillEllipse(Brushes.Gold, new(10, 10, 75, 75));
                g.FillRectangle(Brushes.ForestGreen, new(0, 300, 800, 150));

                g.DrawLine(brownPen, new Point(732, -6), new Point(732, 30));
                g.DrawImageUnscaled(HiveOutside, 693, 12);
                foreach(Flower flower in world.Flowers)
                {
                    g.DrawImageUnscaled(Flower, flower.Location.X, flower.Location.Y);
                }
                foreach(Bee bee in world.Bees)
                {
                    if (!bee.InsideHive)
                    {
                        g.DrawImageUnscaled(BeeAnimationSmall[Cell],
                            bee.Location.X, bee.Location.Y);
                        g.FillRectangle(Brushes.Red, new(bee.Location.X, bee.Location.Y + 5,(1000 - bee.Age)/50, 4));
                    }
                }
                foreach(Wasp wasp in world.Wasps)
                {
                    if(wasp != null)
                    {
                        g.DrawImageUnscaled(BeeAnimationSmall[Cell],
                            wasp.Location.X, wasp.Location.Y);
                    }
                }

            }

        }

        
        public static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using(Graphics graphics = Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture, 0, 0, width, height);
            }
            return resizedPicture;
        }

        
    }
}
