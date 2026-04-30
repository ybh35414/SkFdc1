using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.DataSources;
using ScottPlot.Plottables;
using ScottPlot.Statistics;
using ScottPlot.WinForms;
using SkFdc1.Controllers;
using SkFdc1.Helpers;
using SkFdc1.Models;
using SkFdc1.Services.Business.Lot;
using System;
using System.Diagnostics;


namespace SkFdc1
{
	public partial class MainForm : Form
	{
		private readonly LotController _controller;
		private readonly SensorChartService _chartService;	

		public MainForm(LotController lotController)
		{
			InitializeComponent();

			_controller = lotController;
			_chartService = new SensorChartService(lotController);

			// 이벤트 연결
			_chartService.OnError += OnSensorError;

			// 서비스에 차트 세팅
			_chartService.SetChartObject(new List<FormsPlot>() { formsPlot1, formsPlot2, formsPlot3 });
		}

		#region 이벤트
		private async void MainForm_Load(object sender, EventArgs e)
		{
			await LoadLotList();
		}

		// 그리드셀 클릭 이벤트 - LOT 상세정보 및 센서데이터 조회
		private async void grdList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			DataGridViewRow row = grdList.Rows[e.RowIndex];
			string? lotId = row.Cells["lotId"].Value.ToString();
			if (string.IsNullOrEmpty(lotId)) return;

			// 기존 타이머 정지
			_chartService.StopTimer();

			// LOT 상세정보 조회
			await ViewDetailInfo(lotId);

			// 센서 타입 조회 후 차트 초기화
			List<SensorTypeIdDto> sensorTypes = await _controller.GetSensorTypeIds(lotId);
			_chartService.InitAllCharts(sensorTypes);

			// 타이머 시작
			_chartService.StartTimer(lotId);
		}

		#endregion

		#region 내부함수

		// 에러 이벤트 → 메시지 표시
		private void OnSensorError(object? sender, string message)
		{
			MessageHelper.ShowError(message);
		}

		// LOT 리스트 조회
		private async Task LoadLotList()
		{
			List<LotViewDto> lots = await _controller.GetLotViewList();
			grdList.DataSource = lots;
		}

		// LOT 상세정보 조회
		private async Task ViewDetailInfo(string lotId)
		{
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

		#endregion

	}
}
