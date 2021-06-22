
namespace Encuesta.Forms
{
    partial class RecuperarForm
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
            this.cmdDir = new System.Windows.Forms.Button();
            this.lblDir = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.cmdRecovery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdDir
            // 
            this.cmdDir.FlatAppearance.BorderSize = 0;
            this.cmdDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDir.Image = global::Encuesta.Properties.Resources.open_folder;
            this.cmdDir.Location = new System.Drawing.Point(384, 75);
            this.cmdDir.Name = "cmdDir";
            this.cmdDir.Size = new System.Drawing.Size(33, 28);
            this.cmdDir.TabIndex = 6;
            this.cmdDir.UseVisualStyleBackColor = true;
            this.cmdDir.Click += new System.EventHandler(this.cmdDir_Click);
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(26, 52);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(55, 13);
            this.lblDir.TabIndex = 5;
            this.lblDir.Text = "Directorio:";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(119, 49);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(314, 20);
            this.txtDir.TabIndex = 4;
            // 
            // cmdRecovery
            // 
            this.cmdRecovery.Location = new System.Drawing.Point(254, 118);
            this.cmdRecovery.Name = "cmdRecovery";
            this.cmdRecovery.Size = new System.Drawing.Size(72, 22);
            this.cmdRecovery.TabIndex = 7;
            this.cmdRecovery.Text = "Recuperar";
            this.cmdRecovery.UseVisualStyleBackColor = true;
            this.cmdRecovery.Click += new System.EventHandler(this.cmdRecovery_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecuperarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 152);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdRecovery);
            this.Controls.Add(this.cmdDir);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.txtDir);
            this.Name = "RecuperarForm";
            this.Text = "Recuperar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDir;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button cmdRecovery;
        private System.Windows.Forms.Button button1;
    }
}