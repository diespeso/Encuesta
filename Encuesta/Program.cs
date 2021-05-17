using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        static string[] lines = System.IO.File.ReadAllLines(@"DataBaseConnectionString.txt");

        private static Panel _panel;
        private static string _connectionString = lines[0];
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
    }
}
