using System;
using System.Collections.Generic;
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
    public partial class DevicesMainView : Form
    {
        private QuizDeviceServices _deviceServices = new QuizDeviceServices();
        public DevicesMainView()
        {
            InitializeComponent();
        }
        private void DevicesMainView_Load(object sender, EventArgs e)
        {
            dg.DataSource = _deviceServices.GetQuizDeviceList();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new DeviceForm());
        }

        int GetSelectedDataGridItem(int rowIndex)
        {
            return (dg.Rows[rowIndex].DataBoundItem as QuizDeviceDto).QuizDeviceId;
        }

        private void dgQuizes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.SetMainPanelForm(new DeviceForm(GetSelectedDataGridItem(e.RowIndex)));
        }
    }
}
