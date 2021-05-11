using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Encuesta.ENTIDADES
{
    /*INSERTAR DATOS*/
    private void Insert(object sender, EventArgs e)
    {
        try
        {

            string Conexion = "datasource=localhost;port=3306;username=root;password=root";

            string Query = "insert into Encuesta.quiz(quizId,quizName) values('" + this.quizIdTextBox.Text + "','" + this.quizNameTextBox.Text + "');";

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

            string Query = "update Encuesta.quiz set quizId='" + this.quizIdTextBox.Text + "',quizName='" + this.quizNameTextBox.Text + "';";

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

            string Query = "delete from Encuesta.quiz  where quizId='" + this.quizIdTextBox.Text + "';";

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

            string Query = "select * from Encuesta.quiz; ";

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
