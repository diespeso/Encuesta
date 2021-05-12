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
    class answeredquizcrud
    {
        public MySqlConnection con;

        public answeredquizcrud()
        {
            string host = "localhost";
            string db = "ENCUESTA";
            string port = "3306";
            string user = "root";
            string pass = "root";
            string constring = "datasource =" + host + ";database = "+db+"; port =" + port + "; username =" + user + "; password=" + pass + ";SslMode=none";
            con = new MySqlConnection(constring);
        }                 
    }

    class ANSWEREDQUIZ_REPOSITORY : answeredquizcrud
    {

        public string quizid { set; get; }
        public string deviceid { set; get; }
        public string cdate { set; get; }
        public string ctime { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO answeredQuiz(answeredQuizId,quizDeviceId,creationDate,elasedTime) VALUES(@QUIZID,@DEVICEID,@CREAT,@TIME)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUIZID", MySqlDbType.Int32).Value = quizid;
                cmd.Parameters.Add("@DEVICEID", MySqlDbType.Int32).Value = deviceid;
                cmd.Parameters.Add("@CREAT", MySqlDbType.Date).Value = cdate;
                cmd.Parameters.Add("@TIME", MySqlDbType.Time).Value = ctime;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO answeredQuiz SET answeredQuizId=@QUIZID, quizDeviceId=@DEVICEID,creationDate=@CREAT,elasedTime=@TIME WHERE answeredQuizId=@QUIZID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUIZID", MySqlDbType.Int32).Value = quizid;
                cmd.Parameters.Add("@DEVICEID", MySqlDbType.Int32).Value = deviceid;
                cmd.Parameters.Add("@CREAT", MySqlDbType.Date).Value = cdate;
                cmd.Parameters.Add("@TIME", MySqlDbType.Time).Value = ctime;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM answeredQuiz WHERE answeredQuizId=@QUIZID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUIZID", MySqlDbType.Int32).Value = quizid;
           
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM answeredQuiz";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}

