using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SuperSimuladorDeComeiaComDrawn.Renderer;

namespace SuperSimuladorDeComeiaComDrawn
{
    public partial class FieldForm : Form
    {
        bool inializer = true;
        public Renderer renderer;
        public FieldForm()
        {
            InitializeComponent();
            

        }

             


        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox beePicture = new PictureBox();
            beePicture.Location = new Point(10, 10);
            beePicture.Size = new Size(100, 100);
            beePicture.BorderStyle = BorderStyle.FixedSingle;
            //beePicture.Image = ResizeImage(Properties.Resources.Bee_0000_Capa_1, 180, 140);
            
            Controls.Add(beePicture);
            beePicture.BringToFront();
        }

        private void FieldForm_Resize(object sender, EventArgs e)
        {
            
        }

        private void FieldForm_Paint(object sender, PaintEventArgs e)
        {
            renderer.PaintField(e.Graphics);
        }

        private void FieldForm_Click(object sender, EventArgs e)
        {
            
        }

        private void FieldForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }
    }
}
