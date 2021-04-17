using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta
{
    using RespuestaCualitativa = Encuesta.Respuesta.RespuestaCualitativa;

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
                    throw new Exception("Se intentó avanzar en un motor de preguntas completado.");
                }
            } else
            {
                throw new Exception("Se intentó avanzar en un motor de respuestas donde la última pregunta no tiene una respuesta válida.");
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
    }
}
