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
    }
}
