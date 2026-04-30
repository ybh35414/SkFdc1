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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkFdc1
{
    public partial class frmJang : Form
    {
        private readonly LotController _controller;
        private readonly SensorController _sensorController;

        public frmJang(SensorController sensorController, LotController lotController)
        {
            InitializeComponent();
            _controller = lotController;
            _sensorController = sensorController;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadSensor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 조회 실패:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }            
        }

        private async Task LoadSensor()
        {
            List<SensorDto> sensor = await _sensorController.DisplaySensorList();

            //List<SensorDto> sensor = await _controller.GetSensorViewList();

            ////listbox 초기화
            //listBox1.Items.Clear();
            //foreach(var item in sensor)
            //{
            //    listBox1.Items.Add($"센서타입 : {item.SensorType} 장비ID : {item.EquipID}" +
            //        $"센서ID : {item.SensorID} 센서Unit : {item.Unit}");
            //}

            grdList.DataSource = sensor;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSID.Text))
            {
                MessageBox.Show("조회할 ID를 입력해 주세요");
                return;
            }
            try
            {
                await LoadSensorOne(txtSID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 조회 실패:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            
        }

        private async Task LoadSensorOne(string sensorId)
        {
            try
            {
                SensorDto data = await _sensorController.DisplaySensorOne(sensorId);
                if (data == null)
                {
                    MessageBox.Show("조회된 데이터가 없습니다");
                    ClearFields();
                    return;
                }
                txtSensorID.Text = data.SensorID.ToString();
                txtEquipID.Text = data.EquipID.ToString();
                txtSensorType.Text = data.SensorType.ToString();
                txtUnit.Text = data.Unit.ToString();
            }
            catch (ArgumentException ex)
            {
                //잘못된 인자를 넘긴 프로그래밍 오류
                MessageBox.Show($"입력값 오류:{ex.Message}", "오류", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            
        }

        private void ClearFields()
        {
            txtSensorID.Text = "";
            txtEquipID.Text = "";
            txtSensorType.Text = "";
            txtUnit.Text = "";
        }

        private void grdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = grdList.Rows[e.RowIndex];

            txtSensorID.Text = row.Cells["SensorID"].Value.ToString();
            txtEquipID.Text = row.Cells["EquipID"].Value.ToString();
            txtSensorType.Text = row.Cells["SensorType"].Value.ToString();
            txtUnit.Text = row.Cells["Unit"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var validations = new List<(TextBox box, string name)>
            {
                (txtSensorID, "SENSOR_ID"),
                (txtEquipID, "EQUIPMENT_ID"),
                (txtSensorType, "SENSOR_TYPE"),
                (txtUnit, "UNIT")
            };

            foreach (var v in validations)
            {
                if (string.IsNullOrWhiteSpace(v.box.Text))
                {
                    MessageBox.Show($"{v.name}를 입력해주세요");
                    v.box.Focus();
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openForm = Application.OpenForms["frmSensorValue"];
            if (openForm == null)
            {
                var f = new frmSensorValue(_sensorController);
                f.Show();
            }
            else
            {
                openForm.Focus();
            }
        }
    }
}
