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
    public partial class Nueva_pregunta : Form
    {
        public Nueva_pregunta()
        {
            InitializeComponent();
            string pregunta;
            pregunta = txtpregunta.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtnombredispositivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoDispositivo frmselec = new NuevoDispositivo();
            frmselec.Show();
            this.Hide();
        }

        private void Nueva_pregunta_Load(object sender, EventArgs e)
        {

        }
    }
}
