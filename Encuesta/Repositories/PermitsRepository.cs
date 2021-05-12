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
    class permitscrud
    {
        public MySqlConnection con;

        public permitscrud()
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

    class PERMITS_REPOSITORY : permitscrud
    {

        public string per { set; get; }
        public string pernm { set; get; }



        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO permits(permitId,permitName) VALUES(@PERID,@PERNAME)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@PERID", MySqlDbType.Int32).Value = per;
                cmd.Parameters.Add("@PERNAME", MySqlDbType.VarChar).Value = pernm;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO permits SET permitId=@PERID, permitName=@PERNAME WHERE permitId=@PERID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@PERID", MySqlDbType.Int32).Value = per;
                cmd.Parameters.Add("@PERNAME", MySqlDbType.VarChar).Value = pernm;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM permits WHERE permitId=@PERID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@PERID", MySqlDbType.Int32).Value = per;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM permits";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
