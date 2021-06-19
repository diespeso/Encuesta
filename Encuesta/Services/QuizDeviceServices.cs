using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms.VisualStyles;
using Encuesta.Models;
using Encuesta.Models.Dto;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class QuizDeviceServices
    {
        private QuizDeviceRepository _quizDeviceRepository = new QuizDeviceRepository(Program.GetConnectionString());

        private QuestionRepository _questionRepository = new QuestionRepository(Program.GetConnectionString());

        private QuizRepository _quizRepository = new QuizRepository(Program.GetConnectionString());

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

        public List<QuizDeviceDto> GetQuizDeviceList()
        {
            try
            {
                return _quizDeviceRepository.GetAll()
                    .Select(x => new QuizDeviceDto()
                    {
                        QuizDeviceId = x.QuizDeviceId,
                        QuizToApplyId = x.QuizToApplyId,
                        QuizName = _quizRepository.Get(x.QuizToApplyId).QuizName,
                        QuizDeviceLocation = x.QuizDeviceLocation,
                        QuizDeviceName = x.QuizDeviceName
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new List<QuizDeviceDto>();
            }
        }

        public void SaveDevice(QuizDeviceDto device)
        {
            //ValidateDevice(device);

            if (device.QuizDeviceId == 0)
            {
                //Add Device
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        QuizDeviceModel quizDeviceModel = new QuizDeviceModel()
                        {
                            QuizDeviceLocation = device.QuizDeviceLocation,
                            QuizDeviceName = device.QuizDeviceName,
                            QuizToApplyId = device.QuizToApplyId
                        };

                        _quizDeviceRepository.Add(quizDeviceModel);
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error en repositorio:\n{ex.Message}");
                    }
                }
            }
            else
            {
                //Update Device
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        QuizDeviceModel quizDeviceModel = _quizDeviceRepository.Get(device.QuizDeviceId);
                        quizDeviceModel.QuizDeviceName = device.QuizDeviceName;
                        quizDeviceModel.QuizDeviceLocation = device.QuizDeviceLocation;
                        quizDeviceModel.QuizToApplyId = device.QuizToApplyId;
                        
                        _quizDeviceRepository.Update(quizDeviceModel);

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en repositorio");
                    }
                }
            }
        }

        public QuizDeviceDto GetDevice(int deviceId = 0)
        {
            QuizDeviceDto item = new QuizDeviceDto();
            
            if (deviceId == 0)
                return item;

            QuizDeviceModel model = _quizDeviceRepository.Get(deviceId);
            item.QuizDeviceName = model.QuizDeviceName;
            item.QuizDeviceId = model.QuizDeviceId;
            item.QuizDeviceLocation = model.QuizDeviceLocation;
            item.QuizToApplyId = model.QuizToApplyId;
            item.QuizName = _quizRepository.Get(item.QuizToApplyId).QuizName;
            return item;
        }
    }
}
