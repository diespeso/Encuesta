using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models.Dto;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class ReportServices
    {
        private QuizRepository _quizRepository = new QuizRepository(Program.GetConnectionString());
        public List<Tuple<String, Dictionary<Respuesta.RespuestaCualitativa, int>>> GetQuizResultsByMonthAndYear(int year, int monthNumber, int quizId)
        {
            List<Tuple<String, Dictionary<Respuesta.RespuestaCualitativa, int>>> resultados =
                new List<Tuple<string, Dictionary<Respuesta.RespuestaCualitativa, int>>>();

            List<QuizReportDto> quizResults = _quizRepository.GetQuizResultsByYearAndMonth(year, monthNumber, quizId);

            if (quizResults != null)
            {
                var answeredQuestion = quizResults.GroupBy(x => x.QuestionId).ToList();

                foreach (var question in answeredQuestion)
                {
                    var questionResults = quizResults.Where(x => x.QuestionId == question.First().QuestionId);

                    Dictionary<Respuesta.RespuestaCualitativa, int> diccionarioResultados =
                        new Dictionary<Respuesta.RespuestaCualitativa, int>();

                    int answerCount = 0;
                    foreach (var questionResult in questionResults)
                    {
                        diccionarioResultados.Add(GetRespuestaCualitativa(questionResult.Answer), questionResult.Quantity);
                        answerCount++;
                    }

                    if (answerCount < 5)
                    {
                        foreach (Respuesta.RespuestaCualitativa respuestaCualitativa in Enum.GetValues(typeof(Respuesta.RespuestaCualitativa)).Cast<Respuesta.RespuestaCualitativa>())
                        {
                            if (!diccionarioResultados.ContainsKey(respuestaCualitativa))
                            {
                                diccionarioResultados.Add(respuestaCualitativa, 0);
                            }
                        }
                    }

                    resultados.Add(new Tuple<string, Dictionary<Respuesta.RespuestaCualitativa, int>>(question.First().Question, diccionarioResultados));
                }
            }
            else
            {
                throw new NullReferenceException("No hay datos para la encuesta");
            }
            

            return resultados;
        }

        Respuesta.RespuestaCualitativa GetRespuestaCualitativa(string answer)
        {
            switch (answer)
            {
                case "[icon:star1]":
                    return Respuesta.RespuestaCualitativa.TERRIBLE;
                case "[icon:star2]":
                    return Respuesta.RespuestaCualitativa.MALO;
                case "[icon:star3]":
                    return Respuesta.RespuestaCualitativa.REGULAR;
                case "[icon:star4]":
                    return Respuesta.RespuestaCualitativa.BUENO;
                case "[icon:star5]":
                    return Respuesta.RespuestaCualitativa.EXCELENTE;
                default:
                    return Respuesta.RespuestaCualitativa.INVALIDO;
            }
        }
    }
}
