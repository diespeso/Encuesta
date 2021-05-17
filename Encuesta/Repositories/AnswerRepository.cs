using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories
{
    public class AnswerRepository : RepositoryBase
    {
        public AnswerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AnswerModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO encuesta.answer (answerGroupId, answer) VALUES(@answerGroupId, @answer);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupId", model.AnswerGroupId);
                        cmd.Parameters.AddWithValue("@answer", model.Answer);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        model.AnswerId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(AnswerModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE encuesta.answer SET answerGroupId=@answerGroupId, answer=@answer WHERE answerId=@answerId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupId", model.AnswerGroupId);
                        cmd.Parameters.AddWithValue("@answer", model.Answer);
                        cmd.Parameters.AddWithValue("@answerId", model.AnswerId);
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

        public AnswerModel Get(int answerId)
        {
            AnswerModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT answerId, answerGroupId, answer FROM encuesta.answer where answerId = @answerId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerId", answerId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new AnswerModel();
                                    item.AnswerId = Convert.ToInt32(dr["answerId"]);
                                    item.AnswerGroupId = Convert.ToInt32(dr["answerGroupId"]);
                                    item.Answer = dr["answer"].ToString();
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

        public IEnumerable<AnswerModel> GetAll()
        {
            List<AnswerModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from answer;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<AnswerModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new AnswerModel()
                                    {
                                        AnswerId = Convert.ToInt32(dr["answerId"]),
                                        AnswerGroupId = Convert.ToInt32(dr["answerGroupId"]), 
                                        Answer = dr["answer"].ToString()
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

        public bool Delete(int answerId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM encuesta.answer WHERE answerId=@answerId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerId", answerId);
                        con.Open();
                        cmd.ExecuteNonQuery();
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
