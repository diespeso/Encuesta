using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

using Encuesta.Properties;

//TODO: RENOMBRAR LABEL1 A LBLPREGUNTA O ALGO ASI

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
            Pregunta prim = this.motor.GetPreguntaActual(); //primera pregunta
            label1.Text = prim.GetPreguntaTextual(); //mostrar la primera pregunta

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //antes se usaba para avanzar, es automatico ahora
        }

        public void Limpiar()
        {
            label1.Text = "";
            estrella_1.Hide();
            estrella_2.Hide();
            estrella_3.Hide();
            estrella_4.Hide();
            estrella_5.Hide();
        }

        /// <summary>
        /// Es importante que los nombres sean estrella_1, estrella_2, etc. en orden y terminando con el numero.
        /// Este método se llama cuando el usuario le da click a una estrella para calificar satisfacción.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnEstrellaCalificada(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            char[] calificada_chars = pb.Name.ToCharArray();
            ReiniciarEstrellas();
            CalificarPreguntaActualCon(int.Parse(calificada_chars[calificada_chars.Length - 1].ToString()));
        }

        /// <summary>
        /// Esta función califica la pregunta actual mostrada al usuario, esto quiere decir que colorea las estrellas que identifican
        /// a la calificación dada y que aparte actualiza el valor de la respuesta en la pregunta actual en el motor de preguntas.
        /// </summary>
        /// <param name="calificacion">valor numerico para calificar donde 1 significa terrible y 5 excelente</param>
        public async void CalificarPreguntaActualCon(int calificacion)
        {
            switch (calificacion)
            {
                case 5:
                    estrella_5.Image = Resources.silueta_de_estrella_dorada;
                    estrella_4.Image = Resources.silueta_de_estrella_dorada;
                    estrella_3.Image = Resources.silueta_de_estrella_dorada;
                    estrella_2.Image = Resources.silueta_de_estrella_dorada;
                    estrella_1.Image = Resources.silueta_de_estrella_dorada;
                    break;
                case 4:
                    estrella_4.Image = Resources.silueta_de_estrella_dorada;
                    estrella_3.Image = Resources.silueta_de_estrella_dorada;
                    estrella_2.Image = Resources.silueta_de_estrella_dorada;
                    estrella_1.Image = Resources.silueta_de_estrella_dorada;
                    break;
                case 3:
                    estrella_3.Image = Resources.silueta_de_estrella_dorada;
                    estrella_2.Image = Resources.silueta_de_estrella_dorada;
                    estrella_1.Image = Resources.silueta_de_estrella_dorada;
                    break;
                case 2:
                    estrella_2.Image = Resources.silueta_de_estrella_dorada;
                    estrella_1.Image = Resources.silueta_de_estrella_dorada;
                    break;
                case 1:
                    estrella_1.Image = Resources.silueta_de_estrella_dorada;
                    break;
                default:
                    throw new Exception(String.Format("Se intentó llamar CalificarPreguntaActualCon con un valor de calificación inválido: {0}", calificacion));
            }
            Console.WriteLine(String.Format("Pregunta acutal será contestada con el valor: {0}", Respuesta.IntToRespuestaCualitativa(calificacion)));
            this.motor.Responder(Respuesta.IntToRespuestaCualitativa(calificacion));
            await Task.Delay(1000); //espera 1 segundo
            AvanzarPregunta(); //avanza automaticamente
        }

        private void AvanzarPregunta()
        {
            //mostrar la pregunta actual antes de avanzar
            Console.WriteLine(String.Format("Pregunta actual: {0}", this.motor.GetPreguntaActual()));
            Console.WriteLine(String.Format("Pregunta actual contestada con: {0}", motor.GetPreguntaActual().GetRespuesta()));
            try
            {
                motor.Avanzar();
            }
            catch (NoContestadoException ex)
            {
                MessageBox.Show("Por favor conteste la pregunta antes de avanzar");
            }
            catch (AvanzarEnCompletadoException ex)
            {
                Console.WriteLine("Todas las preguntas del motor fueron contestadas");
                Console.WriteLine("Resultados:");
                foreach (Pregunta preg in motor.ObtenerResultados())
                {
                    Console.WriteLine(String.Format("Pregunta: {0}, Respuesta: {1}", preg.GetPreguntaTextual(), preg.GetRespuesta()));
                }
                Limpiar();
                return;
            }

            label1.Text = this.motor.GetPreguntaActual().GetPreguntaTextual();
            ReiniciarEstrellas();
        }

        public void ReiniciarEstrellas() {
            //nota personal hardcodearlo esta bien si se que seran solo n elementos
            
            this.estrella_1.Image = Resources.silueta_de_estrella_negra;
            this.estrella_2.Image = Resources.silueta_de_estrella_negra;
            this.estrella_3.Image = Resources.silueta_de_estrella_negra;
            this.estrella_4.Image = Resources.silueta_de_estrella_negra;
            this.estrella_5.Image = Resources.silueta_de_estrella_negra;
        }
    }
}
