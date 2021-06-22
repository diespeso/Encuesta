using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Encuesta.Forms
{
    public partial class DBConfigForm : Form
    {
        public DBConfigForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void DBConfigForm_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"DatosBD.txt");
            txtServer.Text = lines[0];
            txtPuerto.Text = lines[1];
            txtUsuario.Text = lines[2];
            txtPassword.Text = lines[3];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Create("DataBaseConnectionString.txt").Close();
            File.AppendAllText("DataBaseConnectionString.txt", $"Server={txtServer.Text};Database=encuesta;Uid={txtUsuario.Text};Pwd={txtPassword.Text};Port={txtPuerto.Text}");

            File.Create("DatosBD.txt").Close();
            File.AppendAllText("DatosBD.txt", $"{txtServer.Text}\n");
            File.AppendAllText("DatosBD.txt", $"{txtPuerto.Text}\n");
            File.AppendAllText("DatosBD.txt", $"{txtUsuario.Text}\n");
            File.AppendAllText("DatosBD.txt", $"{txtPassword.Text}\n");

            Program.RefreshConnectionString();

            MessageBox.Show("Datos guardados");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta operacion borrara la informacion de la base de datos acutal",
                "Inicializar Base de datos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Program.GetConnectionStringWithoutDB()))
                    {
                        using (MySqlCommand command = new MySqlCommand())
                        {
                            using (MySqlBackup backup = new MySqlBackup(command))
                            {
                                command.Connection = connection;
                                connection.Open();
                                backup.ImportFromFile(Directory.GetCurrentDirectory()+ @"\Forms\baseEncuesta.sql");
                                connection.Close();
                            }
                        }
                    }
                    MessageBox.Show("Base de datos inicializada");
                    this.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Fallo al recuperar", ex);
                }
            }
            
        }
    }
}
