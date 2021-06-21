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
    public partial class UserMainView : Form
    {
        private QuizServices _quizServices = new QuizServices();
        public UserMainView()
        {
            InitializeComponent();
        }

        private void UserMainView_Load(object sender, EventArgs e)
        {
            dgQuizes.DataSource = _quizServices.GetQuizList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new QuizForm());
        }

        int GetSelectedQuizId(int rowIndex)
        {
            return (dgQuizes.Rows[rowIndex].DataBoundItem as QuizDto).QuizId;
        }

        private void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.SetMainPanelForm(new QuizForm(GetSelectedQuizId(e.RowIndex)));
        }
    }
}
