﻿
namespace Encuesta
{
    partial class ReporteMes
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart1 = new LiveCharts.Wpf.PieChart();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart2 = new LiveCharts.Wpf.PieChart();
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.btn_anterior = new System.Windows.Forms.Button();
            this.lbl_contador = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.entry_anio = new System.Windows.Forms.TextBox();
            this.combo_meses = new System.Windows.Forms.ComboBox();
            this.combo_encuestas = new System.Windows.Forms.ComboBox();
            this.lbl_pregunta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(440, 159);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(267, 123);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = this.pieChart1;
            // 
            // elementHost2
            // 
            this.elementHost2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.elementHost2.Location = new System.Drawing.Point(165, 127);
            this.elementHost2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(736, 351);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.pieChart2;
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_siguiente.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_siguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_siguiente.Location = new System.Drawing.Point(951, 511);
            this.btn_siguiente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(100, 28);
            this.btn_siguiente.TabIndex = 2;
            this.btn_siguiente.Text = ">";
            this.btn_siguiente.UseVisualStyleBackColor = false;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_click);
            // 
            // btn_anterior
            // 
            this.btn_anterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_anterior.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_anterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_anterior.Location = new System.Drawing.Point(16, 511);
            this.btn_anterior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(100, 28);
            this.btn_anterior.TabIndex = 3;
            this.btn_anterior.Text = "<";
            this.btn_anterior.UseVisualStyleBackColor = false;
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_click);
            // 
            // lbl_contador
            // 
            this.lbl_contador.AutoSize = true;
            this.lbl_contador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_contador.Font = new System.Drawing.Font("Cambria", 7.8F);
            this.lbl_contador.Location = new System.Drawing.Point(507, 511);
            this.lbl_contador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_contador.Name = "lbl_contador";
            this.lbl_contador.Size = new System.Drawing.Size(36, 18);
            this.lbl_contador.TabIndex = 4;
            this.lbl_contador.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 7.8F);
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 7.8F);
            this.label4.Location = new System.Drawing.Point(16, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Encuesta:";
            // 
            // entry_anio
            // 
            this.entry_anio.Location = new System.Drawing.Point(108, 11);
            this.entry_anio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entry_anio.Name = "entry_anio";
            this.entry_anio.Size = new System.Drawing.Size(132, 22);
            this.entry_anio.TabIndex = 8;
            // 
            // combo_meses
            // 
            this.combo_meses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.combo_meses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_meses.FormattingEnabled = true;
            this.combo_meses.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.combo_meses.Location = new System.Drawing.Point(108, 43);
            this.combo_meses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combo_meses.Name = "combo_meses";
            this.combo_meses.Size = new System.Drawing.Size(160, 24);
            this.combo_meses.TabIndex = 10;
            this.combo_meses.SelectedIndexChanged += new System.EventHandler(this.combo_meses_SelectedIndexChanged);
            this.combo_meses.SelectionChangeCommitted += new System.EventHandler(this.combo_meses_SelectionChangeCommitted);
            // 
            // combo_encuestas
            // 
            this.combo_encuestas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.combo_encuestas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_encuestas.Enabled = false;
            this.combo_encuestas.FormattingEnabled = true;
            this.combo_encuestas.Location = new System.Drawing.Point(108, 76);
            this.combo_encuestas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combo_encuestas.Name = "combo_encuestas";
            this.combo_encuestas.Size = new System.Drawing.Size(160, 24);
            this.combo_encuestas.TabIndex = 11;
            this.combo_encuestas.SelectionChangeCommitted += new System.EventHandler(this.combo_encuestas_SelectionChangeCommitted);
            // 
            // lbl_pregunta
            // 
            this.lbl_pregunta.AutoSize = true;
            this.lbl_pregunta.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_pregunta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pregunta.Location = new System.Drawing.Point(461, 76);
            this.lbl_pregunta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pregunta.Name = "lbl_pregunta";
            this.lbl_pregunta.Size = new System.Drawing.Size(2, 19);
            this.lbl_pregunta.TabIndex = 12;
            // 
            // ReporteMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lbl_pregunta);
            this.Controls.Add(this.combo_encuestas);
            this.Controls.Add(this.combo_meses);
            this.Controls.Add(this.entry_anio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_contador);
            this.Controls.Add(this.btn_anterior);
            this.Controls.Add(this.btn_siguiente);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteMes";
            this.Text = "ReporteMes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.PieChart pieChart1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private LiveCharts.Wpf.PieChart pieChart2;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.Button btn_anterior;
        private System.Windows.Forms.Label lbl_contador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox entry_anio;
        private System.Windows.Forms.ComboBox combo_meses;
        private System.Windows.Forms.ComboBox combo_encuestas;
        private System.Windows.Forms.Label lbl_pregunta;
    }
}