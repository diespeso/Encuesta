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
    public class QuestionRepository : RepositoryBase
    {
        public QuestionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(QuestionModel questionModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO question (answerGroupId, question) VALUES(@answerGroupId, @question);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@answerGroupId", questionModel.AnswerGroupId);
                        cmd.Parameters.AddWithValue("@question", questionModel.Question);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        questionModel.QuestionId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(QuestionModel questionModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "UPDATE question SET answerGroupId=@answerGroupId, question=@question WHERE questionId=@questionId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionModel.QuestionId);
                        cmd.Parameters.AddWithValue("@question", questionModel.Question);
                        cmd.Parameters.AddWithValue("@answerGroupId", questionModel.AnswerGroupId);

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

        public QuestionModel Get(int questionId)
        {
            QuestionModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT questionId, answerGroupId, question FROM question where questionId = @questionId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if(dr.HasRows)
                                while (dr.Read())
                                {
                                    item = new QuestionModel();
                                    item.AnswerGroupId = Convert.ToInt32(dr["questionId"]);
                                    item.AnswerGroupId = Convert.ToInt32(dr["answeGroupId"]);
                                    item.Question = dr["question"].ToString();
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

        public IEnumerable<QuestionModel> GetAll()
        {
            List<QuestionModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT questionId, answerGroupId, question FROM question;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuestionModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuestionModel()
                                    {
                                        QuestionId = Convert.ToInt32(dr["questionId"]),
                                        AnswerGroupId = Convert.ToInt32(dr["answerGroupId"].ToString()),
                                        Question = dr["question"].ToString()

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

        public IEnumerable<QuestionModel> GetByQuizId(int quizId)
        {
            List<QuestionModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT q.questionId, q.answerGroupId, q.question FROM question q " +
                                 "INNER JOIN quiz_has_question qhq ON q.questionId = qhq.questionId " +
                                 "WHERE qhq.quizId = @quizId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuestionModel>();
                        con.Open();
                        cmd.Parameters.AddWithValue("@quizId", quizId);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuestionModel()
                                    {
                                        QuestionId = Convert.ToInt32(dr["questionId"]),
                                        AnswerGroupId = Convert.ToInt32(dr["answerGroupId"].ToString()),
                                        Question = dr["question"].ToString()

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

        public bool Delete(int questionId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM question WHERE questionId=@questionId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
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
