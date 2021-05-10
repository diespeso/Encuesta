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
            this.Close();
            NuevoDispositivo nuevoDispositivo = new NuevoDispositivo();
        }

        private void cmdSubirEncuesta_Click(object sender, EventArgs e)
        {
            this.Close();
            SeleccionarEncuesta seleccionarEncuesta = new SeleccionarEncuesta();
        }
    }
}
