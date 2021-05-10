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
    public partial class Menu_Admin : Form
    {
        public Menu_Admin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NuevoDispositivo nuevoDispositivo = new NuevoDispositivo();
            nuevoDispositivo.Show();
        }

        private void cmdSubirEncuesta_Click(object sender, EventArgs e)
        {
            SeleccionarEncuesta seleccionarEncuesta = new SeleccionarEncuesta();
            seleccionarEncuesta.Show();
        }
    }
}
