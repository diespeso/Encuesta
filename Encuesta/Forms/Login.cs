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
        private Timer timerMensaje = new Timer();
        private bool timerFirstCycle = true;
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            timerMensaje.Tick += TimerMensaje_Tick;
            timerMensaje.Interval = 2500;
        }

        private void TimerMensaje_Tick(object sender, EventArgs e)
        {
            if (timerFirstCycle)
                timerFirstCycle = false;
            else
            {
                lblMensajeError.Visible = false;
                timerFirstCycle = true;
                timerMensaje.Stop();
                button1.Enabled = true;
            }
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
            else
            {
                lblMensajeError.Visible = true;
                button1.Enabled = false;
                textBox2.Clear();
                timerMensaje.Start();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
