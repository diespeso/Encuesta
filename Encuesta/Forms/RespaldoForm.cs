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
    public partial class RespaldoForm : Form
    {

        public RespaldoForm()
        {
            InitializeComponent();
        }

        private void cmdDir_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFile = new CommonOpenFileDialog();
            openFile.IsFolderPicker = true;
            if (openFile.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtDir.Text = openFile.FileName;
            }
        }

        private void cmdBackup_Click(object sender, EventArgs e)
        {
            string dir = txtDir.Text + "\backup.sql";
            using (MySqlConnection connection = new MySqlConnection(Program.GetConnectionString()))
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    //using (MySqlBack)
                }
            }
        }
    }
}
