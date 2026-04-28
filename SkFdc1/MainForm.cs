using SkFdc1.Controllers;
using SkFdc1.Models;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.WinForms;

namespace SkFdc1
{
	public partial class MainForm : Form
	{
		private readonly LotController _controller;

		public MainForm()
		{
			InitializeComponent();
			_controller = new LotController();
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			await LoadLotList();
		}

		private async Task LoadLotList()
		{
			List<LotViewDto> lots = await _controller.GetLotViewList();
			grdList.DataSource = lots;
		}

		private async void grdList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			DataGridViewRow row = grdList.Rows[e.RowIndex];
			string lotId = row.Cells["lotId"].Value.ToString();
			LotDetailDto lotDetail = await _controller.GetLotDetail(lotId);
			txtDtl.Text = $"Lot ID: {lotDetail.lotId}\r\n" +
				$"Status: {lotDetail.status}\r\n" +
				$"Start Time: {lotDetail.startTime}\r\n" +
				$"End Time: {lotDetail.endTime}\r\n" +
				$"Priority: {lotDetail.priority}\r\n" +
				$"Product Name: {lotDetail.productName}\r\n" +
				$"Product Type: {lotDetail.productType}\r\n" +
				$"Process Name: {lotDetail.processName}\r\n" +
				$"Equipment Name: {lotDetail.equipmentName}\r\n" +
				$"Equipment Status: {lotDetail.equipmentStatus}\r\n" +
				$"Area Name: {lotDetail.areaName}";
		}
	}
}
