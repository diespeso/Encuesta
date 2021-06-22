using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Forms.FormsKiosko;
using Encuesta.Services;

namespace Encuesta
{
    public partial class Menu_Admin : Form
    {
        private QuizServices _quizServices = new QuizServices();
        private DemoKiosko demo;
        public Menu_Admin()
        {
            InitializeComponent();
            Program.SetMainPanel(this.mainPanel);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Closing += Menu_Admin_Closing;
        }

        private void Menu_Admin_Closing(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new DevicesMainView());
        }

        private void cmdNuevaEncuesta_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new QuizMainView());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSelectDevice selectDevice = new FormSelectDevice();
            if (selectDevice.ShowDialog() == DialogResult.OK)
            {
                KeyValuePair<int, string> device = selectDevice.SelectedDevice;
                if (device.Key != 0 && device.Value != "")
                {
                    demo = new DemoKiosko(device.Value);
                    demo.ShowDialog();
                }
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new ReporteMes(_quizServices.GetQuizKeyValuePair()));
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new UserMainView());
        }
    }
}
