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
    public class UserRoleRepository : RepositoryBase
    {
        public UserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<UserRoleModel> GetAll()
        {
            List<UserRoleModel> list;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT userRoleId, roleName FROM userrole;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        list = new List<UserRoleModel>();
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    list.Add(new UserRoleModel()
                                    {
                                        UserRoleId = Convert.ToInt32(dr["userRoleId"]),
                                        RoleName = dr["roleName"].ToString()
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
