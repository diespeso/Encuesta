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
    public class UserRoleHasPermitRepository : RepositoryBase
    {
        public UserRoleHasPermitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserRoleHasPermitModel Get(int permitId, int roleId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    string sql = "SELECT userRoleId, permitId, permitAllowed FROM encuesta.userrole_has_permit WHERE userRoleId = @userRoleId AND permitId = @permitId;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@permitId", permitId);
                        cmd.Parameters.AddWithValue("@userRoleId", roleId);
                        con.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    return new UserRoleHasPermitModel()
                                    {
                                        PermitId = Convert.ToInt32(dr["permitId"]),
                                        UserRoleId = Convert.ToInt32(dr["userRoleId"]),
                                        PermitAllowed = Convert.ToBoolean(dr["permitAllowed"])
                                    };
                                }
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
