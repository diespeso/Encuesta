
namespace Encuesta
{
    partial class QuizMainView
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
            this.dgQuizes = new System.Windows.Forms.DataGridView();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuizes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgQuizes
            // 
            this.dgQuizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgQuizes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgQuizes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgQuizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuizes.Location = new System.Drawing.Point(12, 43);
            this.dgQuizes.Name = "dgQuizes";
            this.dgQuizes.ReadOnly = true;
            this.dgQuizes.Size = new System.Drawing.Size(776, 395);
            this.dgQuizes.TabIndex = 0;
            this.dgQuizes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQuizes_CellContentClick);
            this.dgQuizes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQuizes_CellDoubleClick);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddQuestion.Image = global::Encuesta.Properties.Resources.add__1_;
            this.btnAddQuestion.Location = new System.Drawing.Point(763, 12);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(25, 25);
            this.btnAddQuestion.TabIndex = 5;
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // QuizMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.dgQuizes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuizMainView";
            this.Text = "QuizMainView";
            this.Load += new System.EventHandler(this.QuizMainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuizes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgQuizes;
        private System.Windows.Forms.Button btnAddQuestion;
    }
}