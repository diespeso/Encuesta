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
    public class PermitRepository : RepositoryBase
    {
        public PermitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(PermitModel permitModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO permits (permitName) VALUES(@permitName);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@permitName", permitModel.PermitName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        permitModel.PermitId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(PermitModel permitModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE permits SET permitName=@permitName WHERE permitId=@permitId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@permitName", permitModel.PermitName);
                        cmd.Parameters.AddWithValue("@permitId", permitModel.PermitId);
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

        public PermitModel Get(int quizId)
        {
            PermitModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT permitId, permitName FROM permits WHERE permitId = @permitId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@permitId", quizId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if(dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new PermitModel();
                                    item.PermitId = Convert.ToInt32(dr["permitId"]);
                                    item.PermitName = dr["permitName"].ToString();
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

        public IEnumerable<PermitModel> GetAll()
        {
            List<PermitModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT permitId, permitName FROM permits;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<PermitModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new PermitModel()
                                    {
                                        PermitId = Convert.ToInt32(dr["permitId"]),
                                        PermitName = dr["permitName"].ToString()
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

        public bool Delete(int permitId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM permits WHERE permitId = @permitId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@permitId", permitId);
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
