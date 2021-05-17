using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Models.Dto;

namespace Encuesta
{
    public partial class Nueva_pregunta : Form
    {
        private QuestionDto _question = new QuestionDto();
        public Nueva_pregunta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _question.Question = txtQuestion.Text;
            this.DialogResult = DialogResult.OK;
        }

        public QuestionDto GetNewQuestion()
        {
            return _question;
        }
    }
}
