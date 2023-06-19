using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;

namespace SuperSimuladorDeComeiaComDrawn
{
    
    public partial class Form1 : Form
    {
        HiveForm hiveForm = new HiveForm();
        FieldForm fieldForm = new FieldForm();
        Renderer renderer;

        Random random = new Random();
        private World world;
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int frameRun = 1000;
        public Form1()
        {
            InitializeComponent();
            MoveChildForms();
            hiveForm.Show(this);
            fieldForm.Show(this);
            ResetSimulator();
            CreateRenderer();

            //world = new World(SendMessage);
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateState(new TimeSpan());
        }

        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = $"Bee # {ID} : {Message}";
            WriteStatics(ID,Message);
            var beeGroups = from bee in world.Bees
                            group bee by bee.CurrentState into beeGroup
                            orderby beeGroup.Key
                            select beeGroup;
            listBox1.Items.Clear();
            foreach(var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                    s = "";
                else
                    s = "s";
                listBox1.Items.Add(group.Key.ToString() + ": "
                    + group.Count() + " bee" + s);
                if(group.Key == BeeState.Idle
                    && group.Count() == world.Bees.Count()
                    && frameRun > 0)
                {
                    listBox1.Items.Add("Simulation ended: all bees are idle");
                    statusStrip1.Items[0].Text = "Simulatio ended";
                    timer1.Enabled = false;
                }
            }


        }

        private void WriteStatics(int ID,string Message)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //controlToRemove.Dispose();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MoveChildForms()
        {
            hiveForm.Location = new Point(Location.X + Width + 10, Location.Y);
            fieldForm.Location = new Point(Location.X,
                Location.Y + Math.Max(Height, hiveForm.Height) + 10);
        }

        private void Tsb_Iniciar_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
                timer2.Start();
                Status.Text = "Correndo";
            }
        }

        private void ResetSimulator()
        {
            frameRun = 0;
            world = new World(new Bee.BeeMessage(SendMessage));
            renderer = new Renderer(world, hiveForm, fieldForm);
           
        }

        private void Tsb_Reniciar_Click(object sender, EventArgs e)
        {
            //renderer.Reset();
            CreateRenderer();
            ResetSimulator();
            if (!timer1.Enabled)
                toolStrip1.Items[0].Text = "Start simulation";
        }

        private void RunFrame(object sender, EventArgs e)
        {
            frameRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateState(frameDuration);
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }

        private void UpdateState(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = string.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (var flower in world.Flowers)
                nectar += flower.Nectar;
            NectarInFlowers.Text = string.Format("{0:f3}", nectar);
            FramesRun.Text = frameRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FrameRate.Text = string.Format("{0:f0}  ({1:f1}ms)",
                                                  1000 / milliSeconds, milliSeconds);
            else
                FrameRate.Text = "N/A";
        }

        private void Tsb_Pausar_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                timer2.Stop();
                Status.Text = "Pausado";
            }
        }

        private void Tsb_Save_Click(object sender, EventArgs e)
        {
            bool eneable = timer1.Enabled;
            if (eneable)
                timer1.Stop();
            world.Hive.SendMessage = null;
            foreach (Bee bee in world.Bees)
                bee.SendMessage -= SendMessage;
            saveFileDialog1.InitialDirectory = @"C:\Users\Fackister\source\repos\SuperSimuladorDeComeia\SuperSimuladorDeComeia\BeeWorld\";
            saveFileDialog1.Filter = "Simulator File (*.bees)|*.bees";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Title = "Choose a file to save the current simulation";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(saveFileDialog1.FileName))
                    {
                        bf.Serialize(output, world);
                        bf.Serialize(output, frameRun);
                    }                   
                    
                       
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Unable to save the simulator file \r\n {ex.Message}",
                        "Bee Simulator Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            world.Hive.SendMessage = new Bee.BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
                bee.SendMessage += SendMessage;
            if (eneable)
                timer1.Start();
        }

        private void Tsb_Load_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramesRun = frameRun;
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();
            openFileDialog1.InitialDirectory = @"C:\Users\Fackister\source\repos\SuperSimuladorDeComeia\SuperSimuladorDeComeia\BeeWorld\";
            openFileDialog1.Filter = "Simulator File (*.bees)|*.bees";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Title = "Choose a file with a simulation to load";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenRead(openFileDialog1.FileName))
                    {
                       world = (World)bf.Deserialize(output);
                       frameRun = (int)bf.Deserialize(output);
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to read the simulator filer \r\n {ex.Message}",
                        "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    frameRun = currentFramesRun;
                }
            }
            world.Hive.SendMessage = SendMessage;
            foreach (Bee bee in world.Bees)
                bee.SendMessage += SendMessage;
            if (enabled)
                timer1.Start();
            CreateRenderer();
            //renderer.Reset();
            renderer = new Renderer(world, hiveForm, fieldForm);

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            MoveChildForms();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            renderer.AnimateBees();
        }

        private void CreateRenderer()
        {
            renderer = new Renderer(world, hiveForm, fieldForm);
            hiveForm.renderer = renderer;
            fieldForm.renderer = renderer;
        }

        private void Tsb_Imprimir_Click(object sender, EventArgs e)
        {
            Tsb_Pausar_Click(sender, e);
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.ShowDialog(this);
            Tsb_Iniciar_Click(sender, e);
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Size stringSize;
            using(Font arial25bold = new Font("Arial", 25, FontStyle.Bold))
            {
                stringSize = Size.Ceiling(
                    g.MeasureString("Bee Simulator", arial25bold));
                g.FillEllipse(Brushes.Gray,
                    new Rectangle(e.MarginBounds.X + 2, e.MarginBounds.Y + 2,
                        stringSize.Width + 30, stringSize.Height + 30));
                g.FillEllipse(Brushes.Black,
                    new Rectangle(e.MarginBounds.X, e.MarginBounds.Y,
                        stringSize.Width + 30, stringSize.Height + 30));
                g.DrawString("Bee Simulator", arial25bold,Brushes.Gray,
                    e.MarginBounds.X + 17,e.MarginBounds.Y + 17);
                g.DrawString("Bee Simulator", arial25bold, Brushes.Gray,
                    e.MarginBounds.X + 15, e.MarginBounds.Y + 15);
            }
            int tableX = e.MarginBounds.X + (int)stringSize.Width + 50;
            int tableWidth = e.MarginBounds.X + e.MarginBounds.Width - tableX - 20;
            int firstColumnX = tableX + 2;
            int secondColumnX = tableX + (tableX / 2) + 5;
            int tableY = e.MarginBounds.Y;

            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Abelhas",Bees.Text );
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Flores", Flowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Mel na colméia",HoneyInHive.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Néctar nas flores", NectarInFlowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Quadros executados", FramesRun.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Taxa de Quadro", FrameRate.Text);
            
            using(Pen blackPen = new Pen(Brushes.Black,2))
            using(Bitmap hiveBipmap = new Bitmap(hiveForm.ClientSize.Width,hiveForm.ClientSize.Height))
            using(Bitmap fieldBitMap = new Bitmap(fieldForm.ClientSize.Width, fieldForm.ClientSize.Height))
            {
                using(Graphics hiveGraphics = Graphics.FromImage(hiveBipmap))
                {
                    renderer.PainHive(hiveGraphics);
                }

                int hiveWidth = e.MarginBounds.Width / 2;
                float ratio = (float)hiveBipmap.Height / (float)hiveBipmap.Width;
                int hiveHeight = (int)(hiveWidth * ratio);
                int hiveX = e.MarginBounds.X + (e.MarginBounds.Width - hiveWidth) / 2;
                int hiveY = e.MarginBounds.Height / 3;
                g.DrawImage(hiveBipmap, hiveX, hiveY, hiveWidth, hiveHeight);
                g.DrawRectangle(blackPen, hiveX, hiveY, hiveWidth, hiveHeight);
                using(Graphics fieldGraphics = Graphics.FromImage(fieldBitMap))
                {
                    renderer.PaintField(fieldGraphics);
                }

                int fieldWidth = e.MarginBounds.Width;
                ratio = (float)fieldBitMap.Height / (float)fieldBitMap.Width;
                int fieldHeight = (int)(fieldWidth * ratio);
                int fieldX = e.MarginBounds.X;
                int fieldY = e.MarginBounds.Y + e.MarginBounds.Height - fieldHeight;
                g.DrawImage(fieldBitMap, fieldX, fieldY, fieldWidth, fieldHeight);
                g.DrawRectangle(blackPen, fieldX, fieldY, fieldWidth, fieldHeight);
            }
        }


        private int PrintTableRow(Graphics printGraphics, int tableX, int tableWidth, int firstColumnX,
            int secondColumnX, int tableY, string firstColumn, string secondColumn
            )
        {
            Font arial12 = new Font("Arial", 12);
            Size stringSize = Size.Ceiling(printGraphics.MeasureString(firstColumn, arial12));
            tableX += 2;
            printGraphics.DrawString(firstColumn, arial12, Brushes.Black, firstColumnX, tableY);
            printGraphics.DrawString(secondColumn, arial12, Brushes.Black, secondColumnX, tableY);

            tableY += (int)stringSize.Height + 2;
            printGraphics.DrawLine(Pens.Black, tableX, tableY - 5, tableX + tableWidth, tableY - 5);
            arial12.Dispose();

            return tableY;
        }
    }

    
}
