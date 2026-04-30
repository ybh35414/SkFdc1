using SkFdc1.Controllers;
using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkFdc1
{
    public partial class frmSensorValue : Form
    {
        private readonly SensorController _sensorController;

        public frmSensorValue(SensorController sensorController)
        {
            InitializeComponent();
            _sensorController = sensorController;
        }

        private async void frmSensorValue_Load(object sender, EventArgs e)
        {
            await loadSensorType();
        }

        private async Task loadSensorType()
        {
            try
            {
                List<SensorTypeDto> sensorType = await _sensorController.DisplaySensorType();
                cboSensorType.DataSource = sensorType;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"센서 타입 로드 실패 : {ex.Message}");
            }            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLotId.Text))
            {
                MessageBox.Show("LOT ID를 입력해주세요");
                return;
            }
            if (string.IsNullOrEmpty(txtSensorType.Text))
            {
                MessageBox.Show("SensorType을 입력해주세요");
                return;
            }

            string lotId = txtLotId.Text;
            string sensorType = txtSensorType.Text;

            List<SensorValuesDto> sensorValues = await _sensorController.DisplaySensorValues(lotId, sensorType);

            grdList.DataSource = sensorValues;
        }


    }
}
