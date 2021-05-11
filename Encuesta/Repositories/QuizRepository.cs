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
    public class QuizRepository
    {
        private string _connectionString;
        public QuizRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(QuizModel quizModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "insert into quiz(quizName) values(@quizName);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizName", quizModel.QuizName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        quizModel.QuizId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(QuizModel quizModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "update quiz set quizName = @quizName where quizId = @quizId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizName", quizModel.QuizName);
                        cmd.Parameters.AddWithValue("@quizId", quizModel.QuizId);
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

        public QuizModel Get(int quizId)
        {
            QuizModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from quiz where quizId = @quizId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizId", quizId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if(dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new QuizModel();
                                    item.QuizId = Convert.ToInt32(dr["quizId"]);
                                    item.QuizName = dr["quizName"].ToString();
                                    return item;
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

        public IEnumerable<QuizModel> GetAll()
        {
            List<QuizModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from quiz;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuizModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuizModel()
                                    {
                                        QuizId = Convert.ToInt32(dr["quizId"]),
                                        QuizName = dr["quizName"].ToString()
                                    });
                                }

                                return list;
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Delete(int quizId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "delete from quiz where quizId = @quizId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizId", quizId);
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
