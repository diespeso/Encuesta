using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RespuestaCualitativa = Encuesta.Respuesta.RespuestaCualitativa;

namespace Encuesta
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        private String pregunta;
        private RespuestaCualitativa respuesta;

        public Pregunta(int idPregunta, String pregunta)
        {
            this.IdPregunta = idPregunta;
            this.pregunta = pregunta;
            this.respuesta = RespuestaCualitativa.INVALIDO;
        }

        public Pregunta(String pregunta, RespuestaCualitativa respuesta)
        {
            this.pregunta = pregunta;
            this.respuesta = respuesta;
        }

        public void SetRespuesta(RespuestaCualitativa respuesta)
        {
            this.respuesta = respuesta;
        }

        public RespuestaCualitativa GetRespuesta()
        {
            return this.respuesta;
        }

        public bool TieneRespuestaValida()
        {
            return this.respuesta != RespuestaCualitativa.INVALIDO;
        }

        public String GetPreguntaTextual()
        {
            return "¿" + this.pregunta+"?";
        }

        public override string ToString()
        {
            return String.Format("/(Pregunta: {0}, Respuesta: {1})", this.pregunta, this.respuesta);
        }
    }
}
