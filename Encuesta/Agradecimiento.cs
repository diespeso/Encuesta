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
    public partial class Agradecimiento : Form
    {
        private Form retorno;
        public Agradecimiento(Form retorno)
        {
            InitializeComponent();
            this.retorno = retorno;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void Agradecimiento_Load(object sender, EventArgs e)
        {
            await Task.Delay(3000); //mostrar por x segundos
            IrARetorno();
        }

        private void IrARetorno()
        {
            this.retorno.Show();
            this.Close();
        }
    }
}
