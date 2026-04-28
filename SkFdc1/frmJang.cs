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
using SkFdc1.Controllers;

namespace SkFdc1
{
    public partial class frmJang : Form
    {
        private readonly LotController _controller;

        public frmJang()
        {
            InitializeComponent();
            _controller = new LotController();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadSensor();
        }

        private async Task LoadSensor()
        {
            List<SensorDto> sensor = await _controller.GetSensorViewList();
        }
    }
}
