using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories 
{
	public class QuizHasQuestionsRepository
	{
		private string connectionString;

		public QuizHasQuestionsRepository(string ConnectionString)
		{
			connectionString = ConnectionString;
		}


		public void Add(QuizHasQuestionModel quizHasQuestionsModel)
		{
			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					string Sql = "insert into quiz_has_question(questionId,quizId) values (@questionId,@quizId)";
					using (MySqlCommand command = new MySqlCommand(Sql, connection))
					{
						command.Parameters.AddWithValue("@questionId", quizHasQuestionsModel.QuestionId);
						command.Parameters.AddWithValue("@QuizId", quizHasQuestionsModel.QuizId);
						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}

		}

		//Revisar si se utilizara
		public void Update(QuizHasQuestionModel quizHasQuestionsModel)
		{
			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					string Sql = "update quiz_has_question set questionId=@questionId where quizId=@quizId";

					using (MySqlCommand command = new MySqlCommand(Sql, connection))
					{
						command.Parameters.AddWithValue("@quizId", quizHasQuestionsModel.QuizId);
						command.Parameters.AddWithValue("@questionId", quizHasQuestionsModel.QuestionId);

						connection.Open();
						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		public QuizHasQuestionModel Get(QuizHasQuestionModel quizHasQuestionsModel )
		{
			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					string Sql = "select * from quiz_has_question where quizId = @quizId and questionId = @questionId";

					using (MySqlCommand cmd = new MySqlCommand(Sql, connection))
					{
                        cmd.Parameters.AddWithValue("quizId", quizHasQuestionsModel.QuizId);
						connection.Open();

						using (MySqlDataReader dr = cmd.ExecuteReader())
						{
							if (dr.HasRows)
                            {
                                QuizHasQuestionModel item = new QuizHasQuestionModel();
								while (dr.Read())
								{
									item = new QuizHasQuestionModel();
									item.QuizId = Convert.ToInt32(dr["quizId"]);
									item.QuestionId = Convert.ToInt32(dr["questionId"]);
									return item;
								}
							}
						}
					}
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
			return null;
		}

		public bool Delete(QuizHasQuestionModel quizHasQuestionsModel)
		{
			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					string Sql = "delete from quiz_has_question where quizId = @quizId and questionId = @questionId";

					using (MySqlCommand command = new MySqlCommand(Sql, connection))
					{
						command.Parameters.AddWithValue("@quizId", quizHasQuestionsModel.QuizId);
						connection.Open();
						command.ExecuteNonQuery();
                        return true;
                    }
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
	}

}