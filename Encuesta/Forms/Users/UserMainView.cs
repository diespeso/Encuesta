using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Forms;
using Encuesta.Models;
using Encuesta.Models.Dto;
using Encuesta.Services;

namespace Encuesta
{
    public partial class UserMainView : Form
    {
        private UserServices _quizServices = new UserServices();
        public UserMainView()
        {
            InitializeComponent();
        }

        private void UserMainView_Load(object sender, EventArgs e)
        {
            dgQuizes.DataSource = _quizServices.GetMainView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new UserForm());
        }

        int GetSelectedQuizId(int rowIndex)
        {
            return (dgQuizes.Rows[rowIndex].DataBoundItem as UserModel).UserId;
        }

        private void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.SetMainPanelForm(new UserForm(GetSelectedQuizId(e.RowIndex)));
        }
    }
}
