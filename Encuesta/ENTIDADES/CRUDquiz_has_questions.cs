using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Encuesta.ENTIDADES
{
    class CRUDquiz_has_questions
    {
        /*INSERTAR DATOS*/
        private void Insert(object sender, EventArgs e)
        {
            try
            {

                string Conexion = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "insert into Encuesta.quiz_has_questions(questionId,quizId) values('" + this.questionIdTextBox.Text + "','" + this.quizIdTextBox.Text + "');";

                MySqlConnection Miconexion = new MySqlConnection(Conexion);

                MySqlCommand Comando = new MySqlCommand(Query, Miconexion);
                MySqlDataReader Lector;
                Miconexion.Open();
                Lector = Comando.ExecuteReader();
                /*
                 MessageBox.Show("Save Data");  
                 while (Lector.Read())  
                  {                     
                   }  
                 Miconexion.Close();*/
            }

            catch (Exception ex)
            {
                /*MessageBox.Show(ex.Message);  */
            }
        }

        /*ACTUALIZAR*/
        private void update(object sender, EventArgs e)
        {
            try
            {

                string Conexion = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "update Encuesta.quiz_has_questions set questionId='" + this.questionId.Text + "',quizId='" + this.quizIdTextBox.Text + "';";

                MySqlConnection Miconexion = new MySqlConnection(Conexion);

                MySqlCommand Comando = new MySqlCommand(Query, Miconexion);
                MySqlDataReader Lector;
                Miconexion.Open();
                Lector = Comando.ExecuteReader();
                /*
                 MessageBox.Show("Update Data");  
                 while (Lector.Read())  
                  {                     
                   }  
                 Miconexion.Close();*/
            }

            catch (Exception ex)
            {
                /*MessageBox.Show(ex.Message);  */
            }
        }

        /*BORRAR*/
        private void delete(object sender, EventArgs e)
        {
            try
            {

                string Conexion = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "delete from Encuesta.quiz_has_questions where questionId='" + this.questionIdTextBox.Text + "';";

                MySqlConnection Miconexion = new MySqlConnection(Conexion);
                MySqlCommand Comando = new MySqlCommand(Query, Miconexion);
                MySqlDataReader Lector;
                Miconexion.Open();
                Lector = Comando.ExecuteReader();
                /*
                 MessageBox.Show("Delete Data");  
                 while (Lector.Read())  
                  {                     
                   }  
                 Miconexion.Close();*/
            }

            catch (Exception ex)
            {
                /*MessageBox.Show(ex.Message);  */
            }
        }

        /*MOSTRAR*/
        private void display(object sender, EventArgs e)
        {
            try
            {

                string Conexion = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select * from Encuesta.quiz_has_questions; ";

                MySqlConnection Miconexion = new MySqlConnection(Conexion);
                MySqlCommand Comando = new MySqlCommand(Query, Miconexion);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = Comando;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }

            catch (Exception ex)
            {
                /*MessageBox.Show(ex.Message);  */
            }
        }
    }
}
