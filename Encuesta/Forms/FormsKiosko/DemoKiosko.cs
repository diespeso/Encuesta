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

namespace Encuesta
{
    public partial class DemoKiosko : Form
    {
        private string _deviceName;
        private int _deviceId;
        private QuizDeviceServices _quizDeviceServices = new QuizDeviceServices();
        private QuizServices _quizServices = new QuizServices();
        private List<Pregunta> preguntas;
        public DemoKiosko(string deviceName)
        {
            InitializeComponent();
            _deviceName = deviceName;
            _deviceId = GetDeviceId();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        int GetDeviceId()
        {
            return _quizDeviceServices.GetDeviceId(_deviceName);
        }

        private void ComenzarAPreguntar(object sender, EventArgs e)
        {
            GUI_Pregunta g_pre = new GUI_Pregunta();

            Agradecimiento ag = new Agradecimiento(this); //pantalla de agradecimiento con retorno a esta forma
            g_pre.AsignarAgradecimiento(ag);
            g_pre.Iniciar(preguntas);

            //Guardar preguntas en BD


            this.Hide(); //la forma padre/bienvenida no se cierra, solo se oculta
            g_pre.ShowDialog();

            try
            {
                _quizServices.SaveAnsweredQuiz(preguntas, _deviceId);
            }
            catch (Exception ex)
            {
                //save to log
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargar preguntas de dipositivo
            try
            {
                preguntas = _quizDeviceServices.GetDeviceQuestions(_deviceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}