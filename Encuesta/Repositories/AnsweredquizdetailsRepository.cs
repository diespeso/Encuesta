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
    class answeredquizdetailscrud
    {
        public MySqlConnection con;

        public answeredquizdetailscrud()
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

    class ANSWEREDQUIZDETAILS_REPOSITORY : answeredquizdetailscrud
    {

        public string aid { set; get; }
        public string qid { set; get; }
        public string allid { set; get; }
    

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO answeredQuizDetails(answerId,questionId,answeredQuizId) VALUES(@ANSWERID,@QUESTIONID,@AQID)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANSWERDID", MySqlDbType.Int32).Value = aid;
                cmd.Parameters.Add("@QUESTIONID", MySqlDbType.Int32).Value = qid;
                cmd.Parameters.Add("@AQID", MySqlDbType.Int32).Value = allid;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO answeredQuizDetails SET answerId=@ANSWERDID, questionId=@QUESTIONID,answeredQuizId=@AQID WHERE answerId=@ANSWERDID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANSWERDID", MySqlDbType.Int32).Value = aid;
                cmd.Parameters.Add("@QUESTIONID", MySqlDbType.Int32).Value = qid;
                cmd.Parameters.Add("@AQID", MySqlDbType.Int32).Value = allid;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM answeredQuizDetails WHERE answerId=@ANSWERDID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ANSWERDID", MySqlDbType.Int32).Value = aid;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM answeredQuizDetails";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
