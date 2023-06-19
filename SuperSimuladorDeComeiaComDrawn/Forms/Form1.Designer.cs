
namespace SuperSimuladorDeComeiaComDrawn
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Tsb_Iniciar = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Pausar = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Reniciar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Load = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Bees = new System.Windows.Forms.Label();
            this.Flowers = new System.Windows.Forms.Label();
            this.HoneyInHive = new System.Windows.Forms.Label();
            this.NectarInFlowers = new System.Windows.Forms.Label();
            this.FramesRun = new System.Windows.Forms.Label();
            this.FrameRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsb_Iniciar,
            this.Tsb_Pausar,
            this.Tsb_Reniciar,
            this.toolStripSeparator1,
            this.Tsb_Save,
            this.Tsb_Load,
            this.Tsb_Imprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(442, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Tsb_Iniciar
            // 
            this.Tsb_Iniciar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Iniciar.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Iniciar.Image")));
            this.Tsb_Iniciar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Iniciar.Name = "Tsb_Iniciar";
            this.Tsb_Iniciar.Size = new System.Drawing.Size(43, 22);
            this.Tsb_Iniciar.Text = "Iniciar";
            this.Tsb_Iniciar.Click += new System.EventHandler(this.Tsb_Iniciar_Click);
            // 
            // Tsb_Pausar
            // 
            this.Tsb_Pausar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Pausar.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Pausar.Image")));
            this.Tsb_Pausar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Pausar.Name = "Tsb_Pausar";
            this.Tsb_Pausar.Size = new System.Drawing.Size(46, 22);
            this.Tsb_Pausar.Text = "Pausar";
            this.Tsb_Pausar.Click += new System.EventHandler(this.Tsb_Pausar_Click);
            // 
            // Tsb_Reniciar
            // 
            this.Tsb_Reniciar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Reniciar.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Reniciar.Image")));
            this.Tsb_Reniciar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Reniciar.Name = "Tsb_Reniciar";
            this.Tsb_Reniciar.Size = new System.Drawing.Size(53, 22);
            this.Tsb_Reniciar.Text = "Reniciar";
            this.Tsb_Reniciar.Click += new System.EventHandler(this.Tsb_Reniciar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Tsb_Save
            // 
            this.Tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Save.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Save.Image")));
            this.Tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Save.Name = "Tsb_Save";
            this.Tsb_Save.Size = new System.Drawing.Size(35, 22);
            this.Tsb_Save.Text = "Save";
            this.Tsb_Save.Click += new System.EventHandler(this.Tsb_Save_Click);
            // 
            // Tsb_Load
            // 
            this.Tsb_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Load.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Load.Image")));
            this.Tsb_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Load.Name = "Tsb_Load";
            this.Tsb_Load.Size = new System.Drawing.Size(37, 22);
            this.Tsb_Load.Text = "Load";
            this.Tsb_Load.Click += new System.EventHandler(this.Tsb_Load_Click);
            // 
            // Tsb_Imprimir
            // 
            this.Tsb_Imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tsb_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Imprimir.Image")));
            this.Tsb_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Imprimir.Name = "Tsb_Imprimir";
            this.Tsb_Imprimir.Size = new System.Drawing.Size(57, 22);
            this.Tsb_Imprimir.Text = "Imprimir";
            this.Tsb_Imprimir.Click += new System.EventHandler(this.Tsb_Imprimir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(57, 17);
            this.Status.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Bees, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Flowers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.HoneyInHive, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NectarInFlowers, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FramesRun, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.FrameRate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 235);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Num. de Flores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total de mel na colméia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total de néctar no campo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "quadros de tempo transcorridos";
            // 
            // Bees
            // 
            this.Bees.AutoSize = true;
            this.Bees.Location = new System.Drawing.Point(223, 0);
            this.Bees.Name = "Bees";
            this.Bees.Size = new System.Drawing.Size(31, 15);
            this.Bees.TabIndex = 7;
            this.Bees.Text = "Bees";
            // 
            // Flowers
            // 
            this.Flowers.AutoSize = true;
            this.Flowers.Location = new System.Drawing.Point(223, 39);
            this.Flowers.Name = "Flowers";
            this.Flowers.Size = new System.Drawing.Size(47, 15);
            this.Flowers.TabIndex = 8;
            this.Flowers.Text = "Flowers";
            // 
            // HoneyInHive
            // 
            this.HoneyInHive.AutoSize = true;
            this.HoneyInHive.Location = new System.Drawing.Point(223, 78);
            this.HoneyInHive.Name = "HoneyInHive";
            this.HoneyInHive.Size = new System.Drawing.Size(76, 15);
            this.HoneyInHive.TabIndex = 9;
            this.HoneyInHive.Text = "HoneyInHive";
            // 
            // NectarInFlowers
            // 
            this.NectarInFlowers.AutoSize = true;
            this.NectarInFlowers.Location = new System.Drawing.Point(223, 117);
            this.NectarInFlowers.Name = "NectarInFlowers";
            this.NectarInFlowers.Size = new System.Drawing.Size(92, 15);
            this.NectarInFlowers.TabIndex = 10;
            this.NectarInFlowers.Text = "NectarInFlowers";
            // 
            // FramesRun
            // 
            this.FramesRun.AutoSize = true;
            this.FramesRun.Location = new System.Drawing.Point(223, 156);
            this.FramesRun.Name = "FramesRun";
            this.FramesRun.Size = new System.Drawing.Size(66, 15);
            this.FramesRun.TabIndex = 11;
            this.FramesRun.Text = "FramesRun";
            // 
            // FrameRate
            // 
            this.FrameRate.AutoSize = true;
            this.FrameRate.Location = new System.Drawing.Point(223, 195);
            this.FrameRate.Name = "FrameRate";
            this.FrameRate.Size = new System.Drawing.Size(63, 15);
            this.FrameRate.TabIndex = 12;
            this.FrameRate.Text = "FrameRate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Taxa de passagem de quadros/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Num. de Abelhas";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 270);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(437, 139);
            this.listBox1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Interval = 40;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(442, 435);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton Tsb_Iniciar;
        private System.Windows.Forms.ToolStripButton Tsb_Pausar;
        private System.Windows.Forms.ToolStripButton Tsb_Reniciar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Bees;
        private System.Windows.Forms.Label Flowers;
        private System.Windows.Forms.Label HoneyInHive;
        private System.Windows.Forms.Label NectarInFlowers;
        private System.Windows.Forms.Label FramesRun;
        private System.Windows.Forms.Label FrameRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Tsb_Save;
        private System.Windows.Forms.ToolStripButton Tsb_Load;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripButton Tsb_Imprimir;
    }
}

