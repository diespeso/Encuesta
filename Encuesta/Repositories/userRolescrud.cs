using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace Encuesta.ENTIDADES
{
    class userRolescrud
    {
        /*CONEXION*/
        public MySqlConnection con;

        public userRolescrud()
        {
            string host = "localhost";
            string db = "ENCUESTA";
            string port = "3306";
            string user = "root";
            string pass = "root";
            string constring = "datasource =" + host + ";database = " + db + "; port =" + port + "; username =" + user + "; password=" + pass + ";SslMode=none";
            con = new MySqlConnection(constring);
        }
    }
    /*INSETAR*/
    class CRUD : userRolescrud
    {

        public string userRoleId { set; get; }
        public string roleName { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO userRoles(userRoleId,roleName) VALUES(@USERROLEID,@ROLENAME)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERROLEID", MySqlDbType.Int32).Value = userRoleId;
                cmd.Parameters.Add("@ROLENAME", MySqlDbType.String).Value = roleName;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /*ACTUALIZAR*/
        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO userRoles SET userRoleId=@USERROLEID, roleName=@ROLENAME";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERROLEID", MySqlDbType.Int32).Value = userRoleId;
                cmd.Parameters.Add("@ROLENAME", MySqlDbType.String).Value = roleName;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /*BORRAR*/
        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM userRoles WHERE userRoleId=@USERROLEID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@USERROLEID", MySqlDbType.Int32).Value = userRoleId;
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        /*leer, mostrar*/
        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM userRoles";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}