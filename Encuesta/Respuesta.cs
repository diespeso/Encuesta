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
        /// <summary>
        /// Devuelve una repuesta cualitativa dependiendo del numero dado, donde un 1 dará TERRIBLE, mientras que un 5 dará EXCELENTE
        /// y cualquier numero que no pueda ser trazado a una respuesta dará INVALIDO
        /// </summary>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        public static RespuestaCualitativa IntToRespuestaCualitativa(int respuesta)
        {
            switch(respuesta)
            {
                case 1:
                    return RespuestaCualitativa.TERRIBLE;
                    break;
                case 2:
                    return RespuestaCualitativa.MALO;
                    break;
                case 3:
                    return RespuestaCualitativa.REGULAR;
                    break;
                case 4:
                    return RespuestaCualitativa.BUENO;
                    break;
                case 5:
                    return RespuestaCualitativa.EXCELENTE;
                    break;
                default:
                    return RespuestaCualitativa.INVALIDO;
            }
        }
    }
}
