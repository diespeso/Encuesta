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
    class answersgroupcrud
    {
        public MySqlConnection con;

        public answersgroupcrud()
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

    class ANSWERSGROUP_REPOSITORY : answersgroupcrud
    {

        public string ansgruid { set; get; }
        public string ansgruname { set; get; }
      


        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO answersGroup(answerGroupId,answerGroupName) VALUES(@AGRID,@AGRNM)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@AGRID", MySqlDbType.Int32).Value = ansgruid;
                cmd.Parameters.Add("@AGRNM", MySqlDbType.VarChar).Value = ansgruname;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE INTO answersGroup SET answerGroupId=@AGRID, answerGroupName=@AGRNM WHERE answerGroupId=@AGRID ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@AGRID", MySqlDbType.Int32).Value = ansgruid;
                cmd.Parameters.Add("@AGRNM", MySqlDbType.VarChar).Value = ansgruname;



                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM answersGroup WHERE answerIdanswerGroupId=@AGRIDANID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@AGRID", MySqlDbType.Int32).Value = ansgruid;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void read_data()
        {
            dt.Clear();
            string query = " SELECT = FROM answersGroup";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
