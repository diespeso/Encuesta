using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories
{
    public class AnsweredQuizDetailRepository:RepositoryBase
    {
        public AnsweredQuizDetailRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(AnsweredQuizDetailModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO encuesta.answeredquizdetail (answerId, questionId, answeredQuizId, elapsedTime) VALUES(@answerId, @questionId, @answeredQuizId, '0');";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerId", model.AnswerId);
                        cmd.Parameters.AddWithValue("@questionId", model.QuestionId);
                        cmd.Parameters.AddWithValue("@answeredQuizId", model.AnsweredQuizId);
                        con.Open();
                        cmd.ExecuteNonQuery();
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
