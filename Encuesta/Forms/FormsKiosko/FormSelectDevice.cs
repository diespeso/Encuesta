using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Repositories;

namespace Encuesta.Forms.FormsKiosko
{
    public partial class FormSelectDevice : Form
    {
        private QuizDeviceRepository _deviceRepository = new QuizDeviceRepository(Program.GetConnectionString());
        private KeyValuePair<int, string> _selectedDevice;
        public KeyValuePair<int,string> SelectedDevice
        {
            get { return _selectedDevice;}
        }

        public FormSelectDevice()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormSelectDevice_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = _deviceRepository.GetAll()
                    .Select(x => new KeyValuePair<int, string>(x.QuizDeviceId, x.QuizDeviceName))
                    .ToList();
                comboBox1.ValueMember = "Key";
                comboBox1.DisplayMember = "Value";
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedDevice = (KeyValuePair<int,string>)comboBox1.SelectedItem;
            this.DialogResult = DialogResult.OK;
        }
    }
}
