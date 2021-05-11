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
    class usersRoles_has_permitscrud
    {
        /*CONEXION*/
        public MySqlConnection con;

        public usersRoles_has_permitscrud()
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
    class CRUD3 : usersRoles_has_permitscrud
    {

        public string userRoleId { set; get; }
        public string permitId { set; get; }
        public string permitAllowed { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO usersRoles_has_permits(userRoleId,permitId,permitAllowed) VALUES(@USERROLEID, @PERMITID,@PERMITALLOWED)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERROLEID", MySqlDbType.Int32).Value = userRoleId;
                cmd.Parameters.Add("@ROLEID", MySqlDbType.Int32).Value = permitId;
                cmd.Parameters.Add("@USERNAME", MySqlDbType.Int32).Value = permitAllowed;
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
                cmd.CommandText = "UPDATE INTO usersRoles_has_permits SET userRoleId=@USERROLEID,permitId=@PERMITID,permitAllowed=@PERMITALLOWED";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERROLEID", MySqlDbType.Int32).Value = userRoleId;
                cmd.Parameters.Add("@ROLEID", MySqlDbType.Int32).Value = permitId;
                cmd.Parameters.Add("@USERNAME", MySqlDbType.Int32).Value = permitAllowed; 
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
                cmd.CommandText = "DELETE FROM usersRoles_has_permits WHERE userRoleId=@USERROLEID";
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
            string query = " SELECT = FROM users";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}