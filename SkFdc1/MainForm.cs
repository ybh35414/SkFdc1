using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.DataSources;
using ScottPlot.Plottables;
using ScottPlot.Statistics;
using ScottPlot.WinForms;
using SkFdc1.Controllers;
using SkFdc1.Models;
using System;
using System.Diagnostics;


namespace SkFdc1
{
	public partial class MainForm : Form
	{
		private readonly LotController _controller;

		private System.Windows.Forms.Timer _timer;

		// 센서종류에 따른 데이터
		private Dictionary<string, List<double>> _tempValue;
		private Dictionary<string, List<double>> _pressValue;
		private Dictionary<string, List<double>> _flowValue;

		// 센서 데이터
		List<(string, DataStreamer)> _tempStreamData;
		List<(string, DataStreamer)> _pressStreamData;
		List<(string, DataStreamer)> _flowStreamData;

		// 현재 lotId
		private string _curLotId;


		public MainForm()
		{
			InitializeComponent();
			_controller = new LotController();
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

			_curLotId = lotId;

			// LOT 상세정보 조회
			await ViewDetailInfo(_curLotId);

			// 센서 타입 조회
			List<SensorTypeIdDto> sensorType = await _controller.GetSensorTypeIds(_curLotId);
			
			// 그래프 작성
			SetGraphData(_curLotId, sensorType);
			
			// 타이머 시작및 그래프 그리기
			InitTimer();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_timer.Stop();
		}
		#endregion

		#region 내부함수

		private void InitTimer()
		{
			_timer = new System.Windows.Forms.Timer();

			// 1초
			_timer.Interval = 1000;
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}


		//private void Timer_Tick(object? sender, EventArgs e)
		//{
		//	// 센서데이터 조회 및 그래프 업데이트
		//	//GetSensorData(_curLotId);

		//	UpdateChart(formsPlot1, _tempValue, _tempStreamData);
		//	UpdateChart(formsPlot2, _pressValue, _pressStreamData);
		//	UpdateChart(formsPlot3, _flowValue, _flowStreamData);
		//}

		private async void Timer_Tick(object? sender, EventArgs e)
		{
			try
			{
				// 타이머 중복 실행 방지 (작업 중이면 타이머 잠시 멈춤)
				_timer.Stop();

				// 비동기로 데이터 가져오기 (await 필수!)
				await GetSensorData(_curLotId);

				// 차트 업데이트
				UpdateChart(formsPlot1, _tempValue, _tempStreamData);
				UpdateChart(formsPlot2, _pressValue, _pressStreamData);
				UpdateChart(formsPlot3, _flowValue, _flowStreamData);
			}
			catch (Exception ex)
			{
				// 여기서 에러 메시지를 확인해보세요! (DB 연결, 데이터 없음 등)
				Debug.WriteLine($"에러 발생: {ex.Message}");
			}
			finally
			{
				// 작업 끝나면 다시 시작
				_timer.Start();
			}
		}

		// 그래프 작성
		private void SetGraphData(string lotId, List<SensorTypeIdDto> sensorType)
		{
			// 센서 아이디별 데이터스트리머
			_tempStreamData = new List<(string, DataStreamer)>();
			_pressStreamData = new List<(string, DataStreamer)>();
			_flowStreamData = new List<(string, DataStreamer)>();

			// 초기화
			List<string> sensorIds;
			sensorIds = sensorType
				.Where(x => x.sensorType.Equals("TEMP"))
				.Select(x => x.sensorId).ToList();
			InitChart(formsPlot1, "FDC Real-Time Monitor(TEMP)", sensorIds, _tempStreamData);

			sensorIds = sensorType
				.Where(x => x.sensorType.Equals("PRESSURE"))
				.Select(x => x.sensorId).ToList();
			InitChart(formsPlot2, "FDC Real-Time Monitor(PRESSURE)", sensorIds, _pressStreamData);

			sensorIds = sensorType
				.Where(x => x.sensorType.Equals("FLOW"))
				.Select(x => x.sensorId).ToList();
			InitChart(formsPlot3, "FDC Real-Time Monitor(FLOW)", sensorIds, _flowStreamData);
		}

		private void UpdateChart(FormsPlot chart, Dictionary<string, List<double>> datas, List<(string, DataStreamer)> streamData)
		{
			if (chart.InvokeRequired)
			{
				chart.Invoke(() =>
					UpdateChart(chart, datas, streamData));
				return;
			}

			// 데이터 갯수만큼 차트작성
			DataStreamer scatter;
			string sensorId;
			double[] xs;
			double[] ys;

			// scatters에 입력된 객체만 그래프 처리
			for (int i = 0; i < streamData.Count; i++)
			{
				sensorId = streamData[i].Item1;

				if (!datas.ContainsKey(sensorId))
					continue;

				DataStreamer sDt = streamData[i].Item2;
				foreach (double item in datas[sensorId])
				{
					sDt.Add(item);
				}
			}

			chart.Refresh();
		}


		// LOT 리스트 조회
		private async Task LoadLotList()
		{
			List<LotViewDto> lots = await _controller.GetLotViewList();
			grdList.DataSource = lots;
		}

		private async Task GetSensorData(string lotId)
		{
			// 기존 데이터 초기화
			_tempValue = new Dictionary<string, List<double>>();
			_pressValue = new Dictionary<string, List<double>>();
			_flowValue = new Dictionary<string, List<double>>();

			// 센서 타입 조회
			List<SensorTypeIdDto> sensorType = await _controller.GetSensorTypeIds(lotId);

			foreach (SensorTypeIdDto sensorTp in sensorType)
			{
				// 데이터 얻어오기 (lastNo 보다 큰거)
				List<SensorDataDto> sensorData = await _controller.GetSensorData(lotId, sensorTp.sensorId, 0);

				if (sensorData.Count == 0)
					continue;

				// List 센서값
				List<double> values = sensorData.Select(sd => sd.sensorValue).ToList();
				// List 데이터 키값
				List<int> dataIds = sensorData.Select(sd => sd.dataId).ToList();

				switch (sensorTp.sensorType.ToUpper())
				{
					case "TEMP":
						_tempValue.Add(sensorTp.sensorId, values);
						break;
					case "PRESSURE":
						_pressValue.Add(sensorTp.sensorId, values);
						break;
					case "FLOW":
						_flowValue.Add(sensorTp.sensorId, values);
						break;
				}
			}
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

		/// <summary>
		/// 그래프 초기화
		/// </summary>
		/// <param name="chart">차트 객체</param>
		/// <param name="title">차트 타이틀명</param>
		/// <param name="datas"><센서아이디, list 값></param>
		/// <param name="scatters">scatter 객체</param>
		private void InitChart(FormsPlot chart, string title,
			List<string> sensorIds, List<(string, DataStreamer)> streamData)
		{
			chart.Reset();

			// 헤더 지정
			chart.Plot.Title(title);
			chart.Plot.XLabel("Time");
			chart.Plot.YLabel("Sensor Value");
			double[] xs;

			Scatter scatter;

			foreach (string dt in sensorIds)
			{
				xs = Enumerable.Range(0, 100).Select(x => (double)x).ToArray();

				scatter = chart.Plot.Add.Scatter(
						xs,
						new double[] { });
				scatter.LegendText = dt;

				// 데이터 갯수 100개로 고정
				DataStreamer streamer = chart.Plot.Add.DataStreamer(100);
				//streamer.ViewScrollLeft();
				streamData.Add((dt, streamer));
			}

			chart.Plot.Axes.AutoScale();
			chart.Plot.ShowLegend();
			chart.Refresh();
		}

		#endregion

	}
}
