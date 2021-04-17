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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GUI_Pregunta g_pre = new GUI_Pregunta();
            List<Pregunta> preguntas = new List<Pregunta>();
            preguntas.Add(new Pregunta("Califica las instalaciones"));
            preguntas.Add(new Pregunta("Califica las luces"));
            g_pre.Iniciar(preguntas);
            g_pre.Show();
        }
    }
}
