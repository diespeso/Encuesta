using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Encuesta.Models;
using Encuesta.Models.Dto;
using Encuesta.Repositories;

namespace Encuesta.Services
{
    public class QuizServices
    {
        private QuizRepository quizRepository = new QuizRepository(Program.GetConnectionString());
        private QuestionRepository questionRepository = new QuestionRepository(Program.GetConnectionString());
        private QuizHasQuestionsRepository quizHasQuestionsRepository = new QuizHasQuestionsRepository(Program.GetConnectionString());

        private AnsweredQuizRepository answeredQuizRepository =
            new AnsweredQuizRepository(Program.GetConnectionString());

        private AnsweredQuizDetailRepository answeredQuizDetailRepository =
            new AnsweredQuizDetailRepository(Program.GetConnectionString());

        public void SaveQuiz(QuizDto quiz)
        {
            ValidateQuiz(quiz);

            if (quiz.QuizId == 0)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        QuizModel quizModel = new QuizModel();
                        quizModel.QuizName = quiz.Name;

                        quizRepository.Add(quizModel);

                        foreach (QuestionDto question in quiz.Questions)
                        {
                            QuestionModel questionModel = new QuestionModel()
                            {
                                Question = question.Question,
                                AnswerGroupId = 1
                            };

                            questionRepository.Add(questionModel);

                            quizHasQuestionsRepository.Add(new QuizHasQuestionModel()
                            {
                                QuizId = quizModel.QuizId,
                                QuestionId = questionModel.QuestionId
                            });
                        }

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
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        quizRepository.Add(new QuizModel()
                        {
                            QuizName = quiz.Name
                        });

                        foreach (QuestionDto question in quiz.Questions)
                        {
                            questionRepository.Add(new QuestionModel()
                            {
                                Question = question.Question,
                                AnswerGroupId = 1
                            });

                            quizHasQuestionsRepository.Add(new QuizHasQuestionModel()
                            {
                                QuizId = quiz.QuizId,
                                QuestionId = question.QuestionId
                            });
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en repositorio");
                    }
                }
            }
        }

        public QuizDto GetQuiz(int quizId = 0)
        {
            if (quizId == 0)
                return new QuizDto()
                {
                    Questions = new ObservableCollection<QuestionDto>()
                };

            QuizDto quizDto = new QuizDto();
            quizDto.Questions = new ObservableCollection<QuestionDto>();

            QuizModel quizModel = quizRepository.Get(quizId);

            quizDto.QuizId = quizModel.QuizId;
            quizDto.Name = quizModel.QuizName;

            List<QuestionModel> questionList = questionRepository.GetByQuizId(quizId).ToList();
            foreach (QuestionModel questionModel in questionList)
            {
                quizDto.Questions.Add(new QuestionDto()
                {
                    QuestionId = questionModel.QuestionId,
                    Question = questionModel.Question
                });
            }

            return quizDto;
        }

        public List<QuizDto> GetQuizList()
        {
            return quizRepository.GetMainView();
        }

        public void AddQuestionToQuiz(QuizDto quiz,QuestionDto question)
        {
            if (quiz.Questions.Count < 5)
            {
                quiz.Questions.Add(new QuestionDto()
                {
                    Question = question.Question
                });
            }
            else
            {
                throw new Exception("Solo se permiten 5 preguntas por encuesta");
            }
        }

        void ValidateQuiz(QuizDto quiz)
        {
            if (quiz.Name == "")
            {
                throw new ArgumentException("La encuesta debe tener un nombre");
            }

            if (quiz.Questions.Count() == 0)
            {
                throw new ArgumentException("Al menos debe existir una pregunta");
            }
        }

        public List<KeyValuePair<int, String>> GetQuizKeyValuePair()
        {
            try
            {
                List<QuizModel> quizList = quizRepository.GetAll().ToList();
                return quizList.ToDictionary(x => x.QuizId, x => x.QuizName).ToList();
            }
            catch (Exception ex)
            {
                return new List<KeyValuePair<int, string>>();
            }
        }

        public void SaveAnsweredQuiz(IEnumerable<Pregunta> preguntas, int deviceId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    AnsweredQuizModel answeredQuiz = new AnsweredQuizModel();
                    answeredQuiz.QuizDeviceId = deviceId;
                    answeredQuizRepository.Add(answeredQuiz);

                    
                    foreach (Pregunta pregunta in preguntas)
                    {
                        answeredQuizDetailRepository.Add(new AnsweredQuizDetailModel()
                        {
                            QuestionId = pregunta.IdPregunta,
                            AnswerId = GetStartAnswerValue(pregunta.GetRespuesta()),
                            AnsweredQuizId = answeredQuiz.AnsweredQuizId
                        });
                    }
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    throw new Exception($"Error en repositorio: {ex.Message}");
                }
            }
        }

        int GetStartAnswerValue(Respuesta.RespuestaCualitativa answer)
        {
            switch (answer)
            {
                case Respuesta.RespuestaCualitativa.TERRIBLE:
                    return 6;
                case Respuesta.RespuestaCualitativa.MALO:
                    return 7;
                case Respuesta.RespuestaCualitativa.REGULAR:
                    return 8;
                case Respuesta.RespuestaCualitativa.BUENO:
                    return 9;
                case Respuesta.RespuestaCualitativa.EXCELENTE:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
