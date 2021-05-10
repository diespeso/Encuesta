using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuesta
{
    public partial class NuevoDispositivo : Form
    {
        public NuevoDispositivo()
        {
            InitializeComponent();
            string nombre;
            nombre = txtnombredispositivo.Text;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarEncuesta frmselec = new SeleccionarEncuesta();
            frmselec.Show();
            this.Hide();
        }

        private void NuevoDispositivo_Load(object sender, EventArgs e)
        {

        }
    }
}
