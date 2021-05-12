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
    class answerscrud
    {
        public MySqlConnection con;

        public answerscrud()
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

    class ANSWERS_REPOSITORY : answerscrud
    {

        public string ansid { set; get; }
        public string agid { set; get; }
        public string answer { set; get; }


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO answers(answerId,answerGroupId,answer) VALUES(@ANID,@AGRUOPID,@AN)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANID", MySqlDbType.Int32).Value = ansid;
                cmd.Parameters.Add("@AGRUOPID", MySqlDbType.Int32).Value = agid;
                cmd.Parameters.Add("@AN", MySqlDbType.VarChar).Value = answer;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO answers SET answerId=@ANID, answerGroupId=@AGRUOPID,answer=@AN WHERE answerId=@ANID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANID", MySqlDbType.Int32).Value = ansid;
                cmd.Parameters.Add("@AGRUOPID", MySqlDbType.Int32).Value = agid;
                cmd.Parameters.Add("@AN", MySqlDbType.VarChar).Value = answer;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM answers WHERE answerId=@ANID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANID", MySqlDbType.Int32).Value = ansid;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM answers";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
