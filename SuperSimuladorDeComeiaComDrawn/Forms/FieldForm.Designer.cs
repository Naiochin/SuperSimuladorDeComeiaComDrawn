
namespace SuperSimuladorDeComeiaComDrawn
{
    partial class FieldForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FieldForm";
            this.Text = "FieldForm";
            this.Click += new System.EventHandler(this.FieldForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FieldForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FieldForm_MouseClick);
            this.Resize += new System.EventHandler(this.FieldForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}