using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta
{
    using RespuestaCualitativa = Encuesta.Respuesta.RespuestaCualitativa;

    public class NoContestadoException: Exception
    {
        public NoContestadoException() : base("Se intentó avanzar en el motor sin haber contestado la pregunta actual")
        {
            
        }
    }

    public class AvanzarEnCompletadoException: Exception
    {
        public AvanzarEnCompletadoException(): base("Se intentó avanzar en un motor de preguntas que ya terminó de correr")
        {

        }
    }

    class MotorPreguntas
    {
        private List<Pregunta> preguntas;
        private int pregunta_actual;

        public MotorPreguntas(List<Pregunta> preguntas)
        {
            this.preguntas = preguntas;
            this.pregunta_actual = 0;
        }

        public void Responder(RespuestaCualitativa respuesta)
        {
            if(this.pregunta_actual < this.preguntas.Count)
            {
                this.preguntas[this.pregunta_actual].SetRespuesta(respuesta);
            } else
            {
                throw new Exception("Se intentó responder una pregunta no existente en una lista de preguntas.");
            }
           
        }

        /// <summary>
        /// Regresa una copia de la pregunta que se acaba de responder, podría ser util o no.
        /// </summary>
        /// <returns></returns>
        public Pregunta Avanzar()
        {
            Pregunta anterior = null;
            if (this.preguntas[this.pregunta_actual].TieneRespuestaValida())
            {
                //avanzar solo si no se ha completado
                if (!this.EsCompletada())
                {
                    anterior = this.preguntas[this.pregunta_actual];
                    this.pregunta_actual++;
                    return anterior;
                } else
                {
                    throw new AvanzarEnCompletadoException();
                }
            } else
            {
                throw new NoContestadoException();
            }
        }

        public Pregunta GetPreguntaActual()
        {
            return this.preguntas[this.pregunta_actual];
        }

        public bool EsCompletada()
        {
            return this.pregunta_actual == this.preguntas.Count - 1;
        }

        /// <summary>
        /// Regresa a la pregunta 0, pero no borra las respuestas de las preguntas
        /// </summary>
        public void ReinicioSuave()
        {
            //not tested
            this.pregunta_actual = 0;
        }

        /// <summary>
        /// Regresa a la pregunta 0 e invalida todas las respuestas, es decir, regresa al estado primordial del motor.
        /// </summary>
        public void ReinicioFuerte()
        {
            //not tested
            ReinicioSuave();
            for(int i = 0; i < this.preguntas.Count; i++)
            {
                this.preguntas[i].SetRespuesta(RespuestaCualitativa.INVALIDO);
            }
        }

        /// <summary>
        /// Solo puede llamarse si el motor ya terminó de correr y todas las preguntas fueron contestadas.
        /// </summary>
        public List<Pregunta> ObtenerResultados()
        {
            if (EsCompletada())
            {
                return this.preguntas;
            }
            throw new Exception("No se pueden obtener resultados de un motor de preguntas sin terminar");
        }
    }
}
