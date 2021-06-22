using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Services;
using Encuesta.Models.Dto;
using MySql.Data.MySqlClient;

namespace Encuesta.Forms
{
    public partial class UserForm : Form
    {
        private UserServices _userServices = new UserServices();
        private UserDto _user = new UserDto();

        public UserForm(int userId = 0)
        {
            InitializeComponent();
            _user = _userServices.GetUser(userId);
            txtUser.Text = _user.UserName;
            txtPass.Text = _user.Password;
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                _user.UserName = txtUser.Text;
                _user.Password= txtPass.Text;
                _user.UserRoleId = Convert.ToInt32(cmbRol.SelectedValue);

                _userServices.Registro(_user);
                Program.SetMainPanelForm(new UserMainView());
            }
            catch(Exception ex)
            {
                throw new Exception("Registro fallido", ex);
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
            cmbRol.DataSource = _userServices.GetUserRoles();
            cmbRol.ValueMember = "Key";
            cmbRol.DisplayMember = "Value";

            cmbRol.SelectedValue = _user.UserRoleId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new UserMainView());
        }
    }
}
