using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;
using System.Text;


namespace Encuesta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitialConfig();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        private static string[] lines;

        private static Panel _panel;
        private static string _connectionString;
        public static void SetMainPanel(Panel panel)
        {
            _panel = panel;
        }

        public static void SetMainPanelForm(Form form)
        {
            form.TopLevel = false;
            _panel.Controls.Clear();
            _panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }

        public static string GetConnectionStringWithoutDB()
        {
            RefreshConnectionString();
            string[] data = System.IO.File.ReadAllLines(@"DatosBD.txt");
            return $"Server={data[0]};Uid={data[2]};Pwd={data[3]};Port={data[1]}";
        }

        static void InitialConfig()
        {
            try
            {
                Directory.CreateDirectory("BackUp");
            }
            catch (Exception ex)
            {

            }
            try
            {
                if(!File.Exists("DataBaseConnectionString.txt")) 
                    File.Create("DataBaseConnectionString.txt").Close();
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (!File.Exists("DatosBD.txt"))
                {
                    File.Create("DatosBD.txt").Close();
                    File.AppendAllText("DatosBD.txt", "127.0.0.1\n");
                    File.AppendAllText("DatosBD.txt", "3306\n");
                    File.AppendAllText("DatosBD.txt", "\n");
                    File.AppendAllText("DatosBD.txt", "\n");
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                lines = System.IO.File.ReadAllLines(@"DataBaseConnectionString.txt");
                _connectionString = lines[0];
            }
            catch (Exception ex)
            {

            }
        }

        public static void RefreshConnectionString()
        {
            try
            {
                lines = System.IO.File.ReadAllLines(@"DataBaseConnectionString.txt");
                _connectionString = lines[0];
            }
            catch (Exception ex)
            {

            }
        }
    }
}
