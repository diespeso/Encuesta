
namespace Encuesta
{
    partial class Menu_Admin
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
            this.lblNuevaEncuesta = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblNuevoDispositivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cmdNuevaEncuesta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNuevaEncuesta
            // 
            this.lblNuevaEncuesta.AutoSize = true;
            this.lblNuevaEncuesta.Location = new System.Drawing.Point(33, 115);
            this.lblNuevaEncuesta.Name = "lblNuevaEncuesta";
            this.lblNuevaEncuesta.Size = new System.Drawing.Size(57, 13);
            this.lblNuevaEncuesta.TabIndex = 6;
            this.lblNuevaEncuesta.Text = "Encuestas";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(118, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(681, 546);
            this.mainPanel.TabIndex = 11;
            // 
            // lblNuevoDispositivo
            // 
            this.lblNuevoDispositivo.AutoSize = true;
            this.lblNuevoDispositivo.Location = new System.Drawing.Point(33, 252);
            this.lblNuevoDispositivo.Name = "lblNuevoDispositivo";
            this.lblNuevoDispositivo.Size = new System.Drawing.Size(63, 13);
            this.lblNuevoDispositivo.TabIndex = 10;
            this.lblNuevoDispositivo.Text = "Dispositivos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Reportes";
            // 
            // btnReports
            // 
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReports.Image = global::Encuesta.Properties.Resources.icons8_business_report_100;
            this.btnReports.Location = new System.Drawing.Point(12, 285);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(100, 100);
            this.btnReports.TabIndex = 12;
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.Window;
            this.button5.Image = global::Encuesta.Properties.Resources.icons8_smartphones_100;
            this.button5.Location = new System.Drawing.Point(12, 149);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 100);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cmdNuevaEncuesta
            // 
            this.cmdNuevaEncuesta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNuevaEncuesta.ForeColor = System.Drawing.SystemColors.Window;
            this.cmdNuevaEncuesta.Image = global::Encuesta.Properties.Resources.icons8_survey_100;
            this.cmdNuevaEncuesta.Location = new System.Drawing.Point(12, 12);
            this.cmdNuevaEncuesta.Name = "cmdNuevaEncuesta";
            this.cmdNuevaEncuesta.Size = new System.Drawing.Size(100, 100);
            this.cmdNuevaEncuesta.TabIndex = 0;
            this.cmdNuevaEncuesta.UseVisualStyleBackColor = true;
            this.cmdNuevaEncuesta.Click += new System.EventHandler(this.cmdNuevaEncuesta_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Image = global::Encuesta.Properties.Resources.icons8_business_report_100;
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Demo";
            // 
            // Menu_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lblNuevoDispositivo);
            this.Controls.Add(this.lblNuevaEncuesta);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cmdNuevaEncuesta);
            this.Name = "Menu_Admin";
            this.Text = "Menu_Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdNuevaEncuesta;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblNuevaEncuesta;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Label lblNuevoDispositivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}