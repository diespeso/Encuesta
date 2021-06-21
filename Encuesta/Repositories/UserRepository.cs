using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Encuesta.Models;

namespace Encuesta.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Registrar
        public void Add(UserModel userModel)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "insert into encuesta.user (roleId,userName,contrasena) values (@roleId,@userName,@contrasena)";

                    using (MySqlCommand command = new MySqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("@roleId", userModel.RoleId);
                        command.Parameters.AddWithValue("@userName", userModel.UserName);
                        command.Parameters.AddWithValue("@contrasena", userModel.Password);
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Update(UserModel model)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "update user set roleId = @roleId, userName = @userName, password = @password where userId = @userId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@quizName", model.QuizName);
                        cmd.Parameters.AddWithValue("@quizId", model.QuizId);
                        cmd.Parameters.AddWithValue("@quizId", model.QuizId);
                        cmd.Parameters.AddWithValue("@quizId", model.QuizId);
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

        public UserModel Get(int userId)
        {
            UserModel item;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from user where userId = @userId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                                while (dr.Read())
                                {
                                    return new UserModel()
                                    {
                                        UserId = Convert.ToInt32(dr["userId"]),
                                        RoleId = Convert.ToInt32(dr["roleId"]),
                                        UserName = dr["userName"].ToString(),
                                        Password = dr["password"].ToString()
                                    };
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

        public IEnumerable<UserModel> GetAll()
        {
            List<UserModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from users;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<UserModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new UserModel()
                                    {
                                        UserId = Convert.ToInt32(dr["userId"]),
                                        RoleId = Convert.ToInt32(dr["roleId"]),
                                        UserName = dr["userName"].ToString(),
                                        Password = dr["password"].ToString()
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

        public List<UserDto> GetMainView()
        {
            List<UserDto> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "select * from quiz;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<UserDto>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new UserDto()
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

        public bool Delete(int userId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "delete from user where userId = @userId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
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