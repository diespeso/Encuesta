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
using Encuesta.Services;

namespace Encuesta
{
    public partial class QuizMainView : Form
    {
        private QuizServices _quizServices = new QuizServices();
        public QuizMainView()
        {
            InitializeComponent();
        }

        private void QuizMainView_Load(object sender, EventArgs e)
        {
            dgQuizes.DataSource = _quizServices.GetQuizList();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (UserServices.ValidateAccess("AgregarEncuestas"))
                Program.SetMainPanelForm(new QuizForm());
        }

        int GetSelectedQuizId(int rowIndex)
        {
            return (dgQuizes.Rows[rowIndex].DataBoundItem as QuizDto).QuizId;
        }

        private void dgQuizes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserServices.ValidateAccess("AgregarEncuestas"))
                Program.SetMainPanelForm(new QuizForm(GetSelectedQuizId(e.RowIndex)));
        }

        private void dgQuizes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
