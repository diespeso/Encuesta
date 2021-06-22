using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Encuesta.Forms
{
    public partial class RecuperarForm : Form
    {
        public RecuperarForm()
        {
            InitializeComponent();
        }

        private void cmdRecovery_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = txtDir.Text;
                using (MySqlConnection connection = new MySqlConnection(Program.GetConnectionString()))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        using (MySqlBackup backup = new MySqlBackup(command))
                        {
                            command.Connection = connection;
                            connection.Open();
                            backup.ImportFromFile(dir);
                            connection.Close();
                        }
                    }
                }
                MessageBox.Show("Base de datos recuperada");
                this.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al recuperar", ex);
            }

        }

        private void cmdDir_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFile = new CommonOpenFileDialog();
            if (openFile.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtDir.Text = openFile.FileName;
            }
        }
    }
}
