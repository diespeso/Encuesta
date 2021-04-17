using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta
{

    public class Respuesta
    {
        public enum RespuestaCualitativa
        {
            TERRIBLE,
            MALO,
            REGULAR,
            BUENO,
            EXCELENTE,
            INVALIDO, //solo para inicializar, nunca debería ser invalido luego de ser contestada
        }

        /// <summary>
        /// Representa una respuesta cualitativa que puede interpretarse como una respuesta cuantitativa posteriormente.
        /// Si se usa el sistema de estrellas una estrella reprensenta terrible, si se usa el de caritas, una cara enojada representa terrible.
        /// </summary>
        public static RespuestaCualitativa StringToRespuestaCualitativa(String respuesta)
        {
            switch (respuesta.ToLower())
            {
                case "terrible":
                    return RespuestaCualitativa.TERRIBLE;
                case "malo":
                    return RespuestaCualitativa.MALO;
                case "bueno":
                    return RespuestaCualitativa.REGULAR;
                case "excelente":
                    return RespuestaCualitativa.EXCELENTE;
                case "INVALIDO":
                    return RespuestaCualitativa.INVALIDO;
                default:
                    throw new Exception("Se intentó convertir a RespuestaCualitativa una String inválida.");
            }
        }
    }
}
