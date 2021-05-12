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
    class questionscrud
    {
        public MySqlConnection con;

        public questionscrud()
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

    class QUESTIONS_REPOSITORY : questionscrud
    {

        public string question { set; get; }
        public string ansgruop { set; get; }
        public string ques { set; get; }



        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO questions(questionId,answerGroupId,question) VALUES(@QUID,@AGRUOPID,@question)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUID", MySqlDbType.Int32).Value = question;
                cmd.Parameters.Add("@AGRUOPID", MySqlDbType.Int32).Value = ansgruop;
                cmd.Parameters.Add("@QU", MySqlDbType.VarChar).Value = ques;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO questions SET questionId=@QUID, answerGroupId=@AGRUOPID, question=question WHERE questionId=@QUID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUID", MySqlDbType.Int32).Value = question;
                cmd.Parameters.Add("@AGRUOPID", MySqlDbType.Int32).Value = ansgruop;
                cmd.Parameters.Add("@QU", MySqlDbType.VarChar).Value = ques;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM questions WHERE questionId=@QUID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@QUID", MySqlDbType.Int32).Value = question;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM questions";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
