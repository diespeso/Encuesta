using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace Encuesta.Repositories
{
    class usersRepository
    {/*CONEXION*/
        public MySqlConnection con;

        public usersRepository()
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
    class CRUD2 : usersRepository
    {

        public string userId { set; get; }
        public string roleId { set; get; }
        public string userName { set; get; }
        public string contrasena { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO users(userId,roleId,userName,contrasena) VALUES(@USERID, @ROLEID,@USERNAME,@CONTRASENA)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERID", MySqlDbType.Int32).Value = userId;
                cmd.Parameters.Add("@ROLEID", MySqlDbType.Int32).Value = roleId;
                cmd.Parameters.Add("@USERNAME", MySqlDbType.String).Value = userName;
                cmd.Parameters.Add("@CONTRASENA", MySqlDbType.String).Value = contrasena;
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
                cmd.CommandText = "UPDATE INTO users SET userId=@USERID,roleId=@ROLEID,userName=@USERNAME,contrasena=@CONTRASENA";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERID", MySqlDbType.Int32).Value = userId;
                cmd.Parameters.Add("@ROLEID", MySqlDbType.Int32).Value = roleId;
                cmd.Parameters.Add("@USERNAME", MySqlDbType.String).Value = userName;
                cmd.Parameters.Add("@CONTRASENA", MySqlDbType.String).Value = contrasena;
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
                cmd.CommandText = "DELETE FROM users WHERE userId=@USERID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add("@USERID", MySqlDbType.Int32).Value = userId;
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