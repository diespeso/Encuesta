
namespace Encuesta.Forms
{
    partial class RespaldoForm
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
            this.lblMain = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.cmdBackup = new System.Windows.Forms.Button();
            this.cmdRecuperar = new System.Windows.Forms.Button();
            this.cmdDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(24, 9);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(395, 37);
            this.lblMain.TabIndex = 0;
            this.lblMain.Text = "Respaldar base de datos";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(121, 79);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(314, 20);
            this.txtDir.TabIndex = 1;
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(28, 82);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(55, 13);
            this.lblDir.TabIndex = 2;
            this.lblDir.Text = "Directorio:";
            // 
            // cmdBackup
            // 
            this.cmdBackup.Location = new System.Drawing.Point(194, 201);
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.Size = new System.Drawing.Size(72, 22);
            this.cmdBackup.TabIndex = 4;
            this.cmdBackup.Text = "Respaldar";
            this.cmdBackup.UseVisualStyleBackColor = true;
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // cmdRecuperar
            // 
            this.cmdRecuperar.FlatAppearance.BorderSize = 0;
            this.cmdRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRecuperar.Image = global::Encuesta.Properties.Resources.import;
            this.cmdRecuperar.Location = new System.Drawing.Point(386, 198);
            this.cmdRecuperar.Name = "cmdRecuperar";
            this.cmdRecuperar.Size = new System.Drawing.Size(33, 28);
            this.cmdRecuperar.TabIndex = 5;
            this.cmdRecuperar.UseVisualStyleBackColor = true;
            this.cmdRecuperar.Click += new System.EventHandler(this.cmdRecuperar_Click);
            // 
            // cmdDir
            // 
            this.cmdDir.FlatAppearance.BorderSize = 0;
            this.cmdDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDir.Image = global::Encuesta.Properties.Resources.open_folder;
            this.cmdDir.Location = new System.Drawing.Point(386, 105);
            this.cmdDir.Name = "cmdDir";
            this.cmdDir.Size = new System.Drawing.Size(33, 28);
            this.cmdDir.TabIndex = 3;
            this.cmdDir.UseVisualStyleBackColor = true;
            this.cmdDir.Click += new System.EventHandler(this.cmdDir_Click);
            // 
            // RespaldoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 235);
            this.Controls.Add(this.cmdRecuperar);
            this.Controls.Add(this.cmdBackup);
            this.Controls.Add(this.cmdDir);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.lblMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RespaldoForm";
            this.Text = "Respaldar";
            this.Load += new System.EventHandler(this.RespaldoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Button cmdDir;
        private System.Windows.Forms.Button cmdBackup;
        private System.Windows.Forms.Button cmdRecuperar;
    }
}