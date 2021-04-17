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

 
    public partial class GUI_Pregunta : Form
    {

        private MotorPreguntas motor;
        
        public GUI_Pregunta()
        {
            InitializeComponent();
        }

        private void GUI_Pregunta_Load(object sender, EventArgs e)
        {

        }

        public void Iniciar(List<Pregunta> preguntas)
        {
            this.motor = new MotorPreguntas(preguntas);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(String.Format("Pregunta actual: {0}", this.motor.GetPreguntaActual()));
            motor.Responder(Respuesta.RespuestaCualitativa.EXCELENTE);
            Console.WriteLine(String.Format("Pregunta respondida: {0}", this.motor.Avanzar()));
        }
    }
}
