
namespace Encuesta
{
    partial class GUI_Pregunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_Pregunta));
            this.label1 = new System.Windows.Forms.Label();
            this.estrella_1 = new System.Windows.Forms.PictureBox();
            this.estrella_2 = new System.Windows.Forms.PictureBox();
            this.estrella_3 = new System.Windows.Forms.PictureBox();
            this.estrella_4 = new System.Windows.Forms.PictureBox();
            this.estrella_5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 131);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // estrella_1
            // 
            this.estrella_1.Image = ((System.Drawing.Image)(resources.GetObject("estrella_1.Image")));
            this.estrella_1.Location = new System.Drawing.Point(240, 272);
            this.estrella_1.Name = "estrella_1";
            this.estrella_1.Size = new System.Drawing.Size(54, 52);
            this.estrella_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.estrella_1.TabIndex = 2;
            this.estrella_1.TabStop = false;
            this.estrella_1.Click += new System.EventHandler(this.OnEstrellaCalificada);
            // 
            // estrella_2
            // 
            this.estrella_2.Image = ((System.Drawing.Image)(resources.GetObject("estrella_2.Image")));
            this.estrella_2.Location = new System.Drawing.Point(300, 272);
            this.estrella_2.Name = "estrella_2";
            this.estrella_2.Size = new System.Drawing.Size(54, 52);
            this.estrella_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.estrella_2.TabIndex = 3;
            this.estrella_2.TabStop = false;
            this.estrella_2.Click += new System.EventHandler(this.OnEstrellaCalificada);
            // 
            // estrella_3
            // 
            this.estrella_3.Image = ((System.Drawing.Image)(resources.GetObject("estrella_3.Image")));
            this.estrella_3.Location = new System.Drawing.Point(360, 272);
            this.estrella_3.Name = "estrella_3";
            this.estrella_3.Size = new System.Drawing.Size(54, 52);
            this.estrella_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.estrella_3.TabIndex = 4;
            this.estrella_3.TabStop = false;
            this.estrella_3.Click += new System.EventHandler(this.OnEstrellaCalificada);
            // 
            // estrella_4
            // 
            this.estrella_4.Image = ((System.Drawing.Image)(resources.GetObject("estrella_4.Image")));
            this.estrella_4.Location = new System.Drawing.Point(420, 272);
            this.estrella_4.Name = "estrella_4";
            this.estrella_4.Size = new System.Drawing.Size(54, 52);
            this.estrella_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.estrella_4.TabIndex = 5;
            this.estrella_4.TabStop = false;
            this.estrella_4.Click += new System.EventHandler(this.OnEstrellaCalificada);
            // 
            // estrella_5
            // 
            this.estrella_5.Image = ((System.Drawing.Image)(resources.GetObject("estrella_5.Image")));
            this.estrella_5.Location = new System.Drawing.Point(480, 272);
            this.estrella_5.Name = "estrella_5";
            this.estrella_5.Size = new System.Drawing.Size(54, 52);
            this.estrella_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.estrella_5.TabIndex = 6;
            this.estrella_5.TabStop = false;
            this.estrella_5.Click += new System.EventHandler(this.OnEstrellaCalificada);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 131);
            this.panel1.TabIndex = 7;
            // 
            // GUI_Pregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.estrella_5);
            this.Controls.Add(this.estrella_4);
            this.Controls.Add(this.estrella_3);
            this.Controls.Add(this.estrella_2);
            this.Controls.Add(this.estrella_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GUI_Pregunta";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.GUI_Pregunta_Load);
            this.Click += new System.EventHandler(this.button1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.estrella_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estrella_5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox estrella_1;
        private System.Windows.Forms.PictureBox estrella_2;
        private System.Windows.Forms.PictureBox estrella_3;
        private System.Windows.Forms.PictureBox estrella_4;
        private System.Windows.Forms.PictureBox estrella_5;
        private System.Windows.Forms.Panel panel1;
    }
}