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
    public partial class Login : Form
    {
        private UserServices _userService = new UserServices();
        private LoginDto _loginData = new LoginDto();
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _loginData.Username = textBox1.Text;
            _loginData.Password = textBox1.Text;
            if (_userService.Login(textBox1.Text,textBox2.Text))
            {
                this.Hide();
                Menu_Admin menu_Admin = new Menu_Admin();
                if (menu_Admin.ShowDialog() == DialogResult.Abort)
                {
                    this.Close();
                }
            }
        }
    }
}
