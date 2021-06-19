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
    public class AnswerGroupRepository : RepositoryBase
    {
        public AnswerGroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AnswersGroupModel PermitModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO answersgroup (answerGroupName) VALUES(@answerGroupName);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupName", PermitModel.AnswerGroupName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        PermitModel.AnswerGroupId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(AnswersGroupModel answersGroupModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE answersgroup SET answerGroupName=@answerGroupName WHERE answerGroupId=@answerGroupId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupName", answersGroupModel.AnswerGroupName);
                        cmd.Parameters.AddWithValue("@answerGroupId", answersGroupModel.AnswerGroupId);
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

        public AnswersGroupModel Get(int AnswersGroupId)
        {
            AnswersGroupModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT answerGroupId, answerGroupName FROM answersgroup where answerGroupId = @answerGroupId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupId", AnswersGroupId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if(dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new AnswersGroupModel();
                                    item.AnswerGroupId = Convert.ToInt32(dr["answerGroupId"]);
                                    item.AnswerGroupName = dr["answerGroupName"].ToString();
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

        public IEnumerable<AnswersGroupModel> GetAll()
        {
            List<AnswersGroupModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT answerGroupId, answerGroupName FROM answersgroup;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<AnswersGroupModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new AnswersGroupModel()
                                    {
                                        AnswerGroupId = Convert.ToInt32(dr["answerGroupId"]),
                                        AnswerGroupName = dr["answerGroupName"].ToString()
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

        public bool Delete(int answersGroupId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM encuesta.answersgroup WHERE answerGroupId=@answerGroupId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupId", answersGroupId);
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
