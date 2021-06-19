using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Models.Dto;
using Encuesta.Services;

namespace Encuesta
{
    public partial class DeviceForm : Form
    {
        private QuizDeviceServices _deviceServices = new QuizDeviceServices();
        private QuizServices _quizServices = new QuizServices();
        private QuizDeviceDto _device = null;
        public DeviceForm()
        {
            InitializeComponent();
            _device = _deviceServices.GetDevice();
        }

        public DeviceForm(int deviceId) : this()
        {
            _device = _deviceServices.GetDevice(deviceId);
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            txtDeviceName.Text = _device.QuizDeviceName;
            txtLocation.Text = _device.QuizDeviceLocation;

            cboQuiz.DataSource = _quizServices.GetQuizKeyValuePair();
            cboQuiz.DisplayMember = "Value";
            cboQuiz.ValueMember = "Key";

            cboQuiz.SelectedValue = _device.QuizToApplyId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new QuizMainView());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _device.QuizName = txtDeviceName.Text;
            _device.QuizDeviceLocation = txtLocation.Text;
            _device.QuizToApplyId = Convert.ToInt32(cboQuiz.SelectedValue);
            try
            {
                _deviceServices.SaveDevice(_device);
                Program.SetMainPanelForm(new DevicesMainView());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
