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

namespace Encuesta.Forms
{
    public partial class RegistroForm : Form
    {
        private UserServices userServices = new UserServices();
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
