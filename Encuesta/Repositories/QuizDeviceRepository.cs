using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories
{
    public class QuizDeviceRepository : RepositoryBase
    {
        public QuizDeviceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(QuizDeviceModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO encuesta.quizdevice (quizToApplyId, quizDeviceName, quizDeviceLocation, dateCreated) " +
                                 "VALUES(@quizToApplyId, @quizDeviceName, @quizDeviceLocation, CURRENT_TIMESTAMP);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizToApplyId", model.QuizToApplyId);
                        cmd.Parameters.AddWithValue("@quizDeviceName", model.QuizDeviceName);
                        cmd.Parameters.AddWithValue("@quizDeviceLocation", model.QuizDeviceLocation);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        model.QuizDeviceId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(QuizDeviceModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE encuesta.quizdevice SET quizToApplyId=@quizToApplyId, quizDeviceName=@quizDeviceName, quizDeviceLocation=@quizDeviceLocation WHERE quizDeviceId=@quizDeviceId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizToApplyId", model.QuizToApplyId);
                        cmd.Parameters.AddWithValue("@quizDeviceName", model.QuizDeviceName);
                        cmd.Parameters.AddWithValue("@quizDeviceLocation", model.QuizDeviceLocation);
                        cmd.Parameters.AddWithValue("@quizDeviceId", model.QuizDeviceId);
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

        public QuizDeviceModel Get(int quizDeviceId)
        {
            QuizDeviceModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT quizDeviceId, quizToApplyId, quizDeviceName, quizDeviceLocation, dateCreated FROM quizdevice WHERE quizDeviceId = @quizDeviceId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizDeviceId", quizDeviceId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            item = new QuizDeviceModel();
                            if (dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new QuizDeviceModel();
                                    item.QuizDeviceId = Convert.ToInt32(dr["quizDeviceId"]);
                                    item.QuizToApplyId = Convert.ToInt32(dr["quizToApplyId"].ToString());
                                    item.QuizDeviceName = dr["quizDeviceName"].ToString();
                                    item.DateCreated = Convert.ToDateTime(dr["dateCreated"]);
                                    return item;
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

            return null;
        }

        public QuizDeviceModel GetByName(string quizDeviceName)
        {
            QuizDeviceModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT quizDeviceId, quizToApplyId, quizDeviceName, quizDeviceLocation, dateCreated FROM quizdevice WHERE quizDeviceName = @quizDeviceName;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizDeviceName", quizDeviceName);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            item = new QuizDeviceModel();
                            if (dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new QuizDeviceModel();
                                    item.QuizDeviceId = Convert.ToInt32(dr["quizDeviceId"]);
                                    item.QuizToApplyId = Convert.ToInt32(dr["quizToApplyId"].ToString());
                                    item.QuizDeviceName = dr["quizDeviceName"].ToString();
                                    item.DateCreated = Convert.ToDateTime(dr["dateCreated"]);
                                    return item;
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

            return null;
        }


        public IEnumerable<QuizDeviceModel> GetAll()
        {
            List<QuizDeviceModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT quizDeviceId, quizToApplyId, quizDeviceName, quizDeviceLocation, dateCreated FROM quizdevice;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuizDeviceModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuizDeviceModel()
                                    {
                                        QuizDeviceId = Convert.ToInt32(dr["quizDeviceId"]),
                                        QuizToApplyId = Convert.ToInt32(dr["quizToApplyId"].ToString()),
                                        QuizDeviceName = dr["quizDeviceName"].ToString(),
                                        DateCreated = Convert.ToDateTime(dr["dateCreated"])
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

        public bool Delete(int quizDeviceId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM quizDevice WHERE quizDeviceId=@quizDeviceId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizDeviceId", quizDeviceId);
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
