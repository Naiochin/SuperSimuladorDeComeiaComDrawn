using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSimuladorDeComeiaComDrawn
{
    public partial class HiveForm : Form
    {
        public Renderer renderer;
        public HiveForm()
        {
            InitializeComponent();
            
        }

        public static void DrawBee(Graphics g, Rectangle rect)
        {
            
        }

        private void HiveForm_Load(object sender, EventArgs e)
        {

        }


        private void HiveForm_Paint(object sender, PaintEventArgs e)
        {
            renderer.PainHive(e.Graphics);
        }

        private void HiveForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MousePosition.ToString());
        }
    }
}
