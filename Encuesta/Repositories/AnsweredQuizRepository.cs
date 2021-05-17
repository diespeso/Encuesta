using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories
{
    public class AnsweredQuizRepository : RepositoryBase
    {
        public AnsweredQuizRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(AnsweredQuizModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO encuesta.answeredquiz (quizDeviceId) VALUES(@quizDeviceId);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizDeviceId", model.QuizDeviceId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        model.AnsweredQuizId = Convert.ToInt32(cmd.LastInsertedId);
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
