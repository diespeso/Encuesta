using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta.Models;
using Encuesta.Models.Dto;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Encuesta.Repositories
{
    public class QuizRepository : RepositoryBase
    {
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

        public List<QuizDto> GetMainView()
        {
            List<QuizDto> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from quiz;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuizDto>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuizDto()
                                    {
                                        QuizId = Convert.ToInt32(dr["quizId"]),
                                        Name = dr["quizName"].ToString()
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

        public bool Delete(int quizId)
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
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<QuizReportDto> GetQuizResultsByYearAndMonth(int year, int monthNumber, int quizId)
        {
            List<QuizReportDto> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = @"select a.answerId, a.answer, q.questionId, q.question , count(*) as quantity from answeredquizdetail aqd
                    inner join answeredquiz aq on aqd.answeredQuizId = aq.answeredQuizId
                    inner join quiz_has_question qhq on qhq.questionId = aqd.questionId
                    inner join question q on q.questionId = aqd.questionId
                    inner join answer a on aqd.answerId = a.answerId
                    where
                    year(aq.creationDate) = @year
                    and month(aq.creationDate) = @monthNumber
                    and qhq.quizId = @quizId
                    group by questionId, answerId;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<QuizReportDto>();
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@monthNumber", monthNumber);
                        cmd.Parameters.AddWithValue("@quizId", quizId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new QuizReportDto()
                                    {
                                        AnswerId = Convert.ToInt32(dr["answerId"]),
                                        Answer = dr["answer"].ToString(),
                                        QuestionId = Convert.ToInt32(dr["questionId"]),
                                        Question = dr["question"].ToString(),
                                        Quantity = Convert.ToInt32(dr["quantity"])
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
    }
}
