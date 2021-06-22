using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using Encuesta.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace Encuesta
{
    using RespuestaCualitativa = Encuesta.Respuesta.RespuestaCualitativa;
    using ResultadoPregunta = Dictionary<Encuesta.Respuesta.RespuestaCualitativa, int>;
    public partial class ReporteMes : Form
    {
        private int contador;
        private List<Tuple<String, ResultadoPregunta>> resultados;
        private ReportServices _reportService = new ReportServices();

        /// <summary>
        /// Una ventana para consultar gráficas de pastel de las respuestas a las preguntas
        /// en un anio y mes especifico, para cualquier encuesta
        /// </summary>
        /// <param name="encuestas"> Una lista con los nombres de las encuestas en la bd.</param>
        public ReporteMes(List<KeyValuePair<int,String>> encuestas)
        {
            InitializeComponent();
            contador = 0;
            CargarComboEncuestas(encuestas);
            ActualizarIndicador();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            int uwu = 40;
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Bueno",
                    Values = new ChartValues<double> {uwu + 10 * 10},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Excelente",
                    Values = new ChartValues<double> {uwu - 20},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            piechartData.Add(
                new PieSeries
                {
                    Title = "Malo",
                    Values = new ChartValues<double> {uwu - 23},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Gray
                });

            pieChart2.Series = piechartData;
            pieChart2.LegendLocation = LegendLocation.Right;

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        
        private void CargarComboEncuestas(List<KeyValuePair<int,String>> encuestas)
        {
            combo_encuestas.DataSource = encuestas;
            combo_encuestas.DisplayMember = "Value";
            combo_encuestas.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //extra, no quiero mover el xml asi que se queda, no hace nada
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //no se usa, lo generé por una confusión, dejarlo para no tener que moverle al xml
        }

        /// <summary>
        /// Valida que el anio sea un numero, se puede meter mas logica de validáción aqui.
        /// </summary>
        /// <returns></returns>
        private int ValidarAnio()
        {
            int res = 0;
            int.TryParse(entry_anio.Text, out res);
            if(res == 0)
            {
                MessageBox.Show("Año inválido");
                return -1;
            }
            return res;

        }

        /// <summary>
        /// Una vez se valida que el mes y el anio sean validos, se activa la selección de la encuesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_meses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Console.WriteLine(combo_meses.SelectedItem.ToString());
            int anio = ValidarAnio();
            if (anio == -1)
            {
                return;
            }
            combo_encuestas.Enabled = true;
        }

        /// <summary>
        /// Cuando se seleccione la encuesta, se hace la consulta de los resultados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_encuestas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int anio = ValidarAnio(); //volver a validar el anio
            if(anio == -1)
            {
                return;
            }

            KeyValuePair<int, string> selectedQuiz = (KeyValuePair<int, string>) combo_encuestas.SelectedItem;

            try
            {
                resultados =
                    _reportService.GetQuizResultsByMonthAndYear(anio, GetSelectedMonthNumber(), selectedQuiz.Key);
                CargarResultadosActuales();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int GetSelectedMonthNumber()
        {
            switch (combo_meses.Text)
            {
                case "Enero":
                    return 1;
                case "Febrero":
                    return 2;
                case "Marzo":
                    return 3;
                case "Abril":
                    return 4;
                case "Mayo":
                    return 5;
                case "Junio":
                    return 6;
                case "Julio":
                    return 7;
                case "Agosto":
                    return 8;
                case "Septiembre":
                    return 9;
                case "Octubre":
                    return 10;
                case "Nomviembre":
                    return 11;
                case "Diciembre":
                    return 12;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Carga a la grafica de pastel los resultados de la pregunta actual, actualiza el texto de la pregunta y el contador de pregunta
        /// </summary>
        public void CargarResultadosActuales()
        {           
            //TODO, al integrar BD: revisar que el resultado de la consulta sea valido antes de regresar la lista,
            //si no lo es mostrar un messagebox y abortar.
            Tuple<String, ResultadoPregunta> actual = resultados[contador];
            lbl_pregunta.Text = actual.Item1;

            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Excelente",
                    Values = new ChartValues<double> {actual.Item2[RespuestaCualitativa.EXCELENTE]},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Bueno",
                    Values = new ChartValues<double> {actual.Item2[RespuestaCualitativa.BUENO]},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Regular",
                    Values = new ChartValues<double> {actual.Item2[RespuestaCualitativa.REGULAR]},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Malo",
                    Values = new ChartValues<double> {actual.Item2[RespuestaCualitativa.MALO]},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Terrible",
                    Values = new ChartValues<double> {actual.Item2[RespuestaCualitativa.TERRIBLE]},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart2.Series = piechartData;

            ActualizarIndicador();
        }

        private void btn_siguiente_click(object sender, EventArgs e)
        {
            if(resultados == null)
            {
                return; //ignorar click
            }
            if(contador == resultados.Count - 1)
            {
                contador = 0; //volver a inicio
            } else
            {
                contador += 1;
            }
            CargarResultadosActuales();
        }

        private void btn_anterior_click(object sender, EventArgs e)
        {
            if(resultados == null)
            {
                return; //ignorar click
            }
            if(contador == 0)
            {
                contador = resultados.Count - 1;
            } else
            {
                contador -= 1;
            }
            CargarResultadosActuales();
        }

        /// <summary>
        /// Actualiza el label que indica en que pregunta va
        /// </summary>
        public void ActualizarIndicador()
        {
            if(resultados != null)
            {
                if(resultados.Count == 0) { //vacio
                    lbl_contador.Text = "N/A";
                } else
                {
                    lbl_contador.Text = String.Format("{0}/{1}", contador + 1, resultados.Count);
                }
            }
                       
        }

        /// <summary>
        /// Consulta la encuesta especifica, en el mes especifico, el anio especifico, contando las respuestas.
        /// solo se requieren los datos: nombre de la pregunta y conteo de las incidencias de cada respuestacualitativa
        /// se espera obtener algo como:
        /// ["que tan limpias estaban las intalaciones?": [RespuestaCualitativa::MALO: 32, RespuestaCualitativa:BUENO: 33]]
        /// </summary>
        /// <param name="encuesta"></param>
        public List<Tuple<String, ResultadoPregunta>> ConsultarEncuesta(String encuesta)
        {
            //por mientras yo lo generaré para pruebas, pero deben ser consultas
            Tuple<String, ResultadoPregunta> pregunta = new Tuple<String, ResultadoPregunta>("que tal la comida?",
                new ResultadoPregunta()
                {
                    {RespuestaCualitativa.TERRIBLE, 32 },
                    {RespuestaCualitativa.MALO, 10 },
                    {RespuestaCualitativa.REGULAR, 10},
                    {RespuestaCualitativa.BUENO, 5},
                    {RespuestaCualitativa.EXCELENTE, 0}
                }
                );
            Tuple<String, ResultadoPregunta> pregunta_2 = new Tuple<String, ResultadoPregunta>("que tal el sabor?",
                new ResultadoPregunta()
                {
                    {RespuestaCualitativa.TERRIBLE, 2},
                    {RespuestaCualitativa.MALO, 0},
                    {RespuestaCualitativa.REGULAR, 20},
                    {RespuestaCualitativa.BUENO, 25},
                    {RespuestaCualitativa.EXCELENTE, 10}
                }
                );

            return new List<Tuple<String, ResultadoPregunta>> { pregunta, pregunta_2 };
        }
    }
}
