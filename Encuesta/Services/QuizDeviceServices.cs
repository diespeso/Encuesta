using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class QuizDeviceServices
    {
        private QuizDeviceRepository _quizDeviceRepository = new QuizDeviceRepository(Program.GetConnectionString());

        private QuestionRepository _questionRepository = new QuestionRepository(Program.GetConnectionString());

        public List<Pregunta> GetDeviceQuestions(string deviceName)
        {
            QuizDeviceModel device = _quizDeviceRepository.GetByName(deviceName);
            List<QuestionModel> questionModel = _questionRepository.GetByQuizId(device.QuizToApplyId).ToList();

            List<Pregunta> lstPreguntas = new List<Pregunta>();
            foreach (QuestionModel model in questionModel)
            {
                lstPreguntas.Add(new Pregunta(model.QuestionId,model.Question));
            }

            if (lstPreguntas.Count() == 0)
            {
                throw new Exception("Dispositivo mal configurado, no tiene ninguna encuesta vinculada.");
            }

            return lstPreguntas;
        }

        public int GetDeviceId(string quizDeviceName)
        {
            try
            {
                QuizDeviceModel device = _quizDeviceRepository.GetByName(quizDeviceName);
                return device.QuizDeviceId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
