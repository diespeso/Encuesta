using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Services;
using Encuesta.Models.Dto;
using MySql.Data.MySqlClient;

namespace Encuesta.Forms
{
    public partial class RegistroForm : Form
    {
        private UserServices userServices = new UserServices();
        private UserDto userDto = new UserDto();
        public RegistroForm()
        {
            InitializeComponent();
            UpdateCombo();
        }

        private void UpdateCombo()
        {
            using (MySqlConnection conn = new MySqlConnection(Program.GetConnectionString()))
            {
                try
                {
                    string query = "select userRoleId,roleName from userrole";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "userrole");
                    cmbRol.DisplayMember = "roleName";
                    cmbRol.ValueMember = "userRoleId";
                    cmbRol.DataSource = ds.Tables["userrole"];

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = cmbRol.SelectedItem.ToString();
                int rol = RolStringAInt(selected);
                userDto.usuario = txtUser.Text;
                userDto.contrasena = txtPass.Text;
                userDto.rol = rol;

                userServices.Registro(userDto);
            }
            catch(Exception ex)
            {
                throw new Exception("Registro fallido", ex);
            }

      
        }

        private int RolStringAInt(string selected)
        {
            int rolId=0;
            switch (selected)
            {
                case "Admin":
                    rolId = 1;

                    break;
                case "User":
                    rolId = 2;
                    break;

            }
            return rolId;
        }
    }
}
