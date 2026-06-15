using ScottPlot.Plottables;
using ScottPlot.WinForms;
using SkFdc1.Controllers;
using SkFdc1.Models;
using SkFdc1.Common; // LogHelper를 위해 추가
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // MethodInvoker를 위해 추가

namespace SkFdc1.Services.Business.Lot
{
	/// <summary>
	/// 센서 그래프 처리 비지니스 로직
	/// </summary>
	public class SensorChartService
	{
		private readonly StatusController _controller;
		private System.Windows.Forms.Timer? _timer;
		private IProgress<ChartUpdatePackage>? _progress;

		// 타입별 센서 데이터 - Service가 보관
		public Dictionary<string, List<double>> TempValue { get; private set; } = new();
		public Dictionary<string, List<double>> PressValue { get; private set; } = new();
		public Dictionary<string, List<double>> FlowValue { get; private set; } = new();

		// 센서 데이터
		List<(string, DataStreamer)> _tempStreamData;
		List<(string, DataStreamer)> _pressStreamData;
		List<(string, DataStreamer)> _flowStreamData;

		// 차트
		private List<FormsPlot> _formsPlot;
		
		// 에러 발생 시 Form에 알림
		public event EventHandler<string>? OnError;

		public SensorChartService(StatusController controller)
		{
			_controller = controller;
		}

		// UI에서 UI 스레드 기반의 Progress 객체를 주입받음
		public void SetProgress(IProgress<ChartUpdatePackage> progress) => _progress = progress;

		public void SetChartObject(List<FormsPlot> formsPlot) => _formsPlot = formsPlot;

		// 차트 처리 시작
		public async void StartChartGraph(int lotKey)
		{
			try
			{
				// 기존 타이머 정지
				StopTimer();

				// 센서 타입 조회 후 차트 초기화
				List<SensorTypeIdDto> sensorTypes = await _controller.GetSensorTypeIds(lotKey);

				List<string> sensorIds = sensorTypes.Select(x => x.sensorId).ToList();
				InitAllCharts(sensorTypes);

				// 타이머 시작
				StartTimer(lotKey);
			}
			catch (Exception ex)
			{
				OnError?.Invoke(this, $"차트 시작 오류 : lotKey: {lotKey} / " + ex.Message);
			}
		}

		


		// 타이머 시작
		private void StartTimer(int lotKey, int interval = 1000)
		{
			StopTimer(); // 기존 타이머 정리

			_timer = new System.Windows.Forms.Timer { Interval = interval };
			_timer.Tick += async (s, e) => await TimerTick(lotKey);
			_timer.Start();
		}

		// 타이머 중지
		private void StopTimer()
		{
			_timer?.Stop();
			_timer?.Dispose();
			_timer = null;
		}

		// 센서 데이터 조회 및 타입별 분류
		private async Task FetchSensorData(int lotKey)
		{
			TempValue = new Dictionary<string, List<double>>();
			PressValue = new Dictionary<string, List<double>>();
			FlowValue = new Dictionary<string, List<double>>();

			try
			{
				List<SensorTypeIdDto> sensorTypes = await _controller.GetSensorTypeIds(lotKey);

				foreach (SensorTypeIdDto sensorTp in sensorTypes)
				{
					List<SensorDataDto> sensorData =
						await _controller.GetSensorData(lotKey, sensorTp.sensorKey);

					if (sensorData.Count == 0) continue;

					List<double> values = sensorData.Select(sd => sd.sensorValue).ToList();

					switch (sensorTp.sensorType.ToUpper())
					{
						case "TEMP": TempValue.Add(sensorTp.sensorId, values); break;
						case "PRESSURE": PressValue.Add(sensorTp.sensorId, values); break;
						case "FLOW": FlowValue.Add(sensorTp.sensorId, values); break;
					}
				}
			}
			catch (Exception ex)
			{
				OnError?.Invoke(this, $"차트 데이터 얻기 오류 : lotKey: {lotKey} / " + ex.Message);
			}
		}

		// 실제 차트 업데이트 처리
		private async Task TimerTick(int lotKey)
		{
			_timer?.Stop();
			try
			{
				// 비동기로 데이터를 가져옴
				await FetchSensorData(lotKey).ConfigureAwait(false);
				// 가져온 데이터를 패키징하여 UI 스레드로 리포트
				var package = new ChartUpdatePackage
				{
					Temp = this.TempValue,
					Press = this.PressValue,
					Flow = this.FlowValue
				};

				_progress?.Report(package);
			}
			catch (Exception ex)
			{
				OnError?.Invoke(this, $"차트 업데이트 오류 : lotKey: {lotKey} / " + ex.Message);
			}
			finally
			{
				_timer?.Start();
			}
		}

		/// <summary>
		/// 모든 차트를 일괄 업데이트합니다.
		/// </summary>
		public void UpdateChartAll(ChartUpdatePackage data)
		{
			UpdateChart(_formsPlot[0], data.Temp, _tempStreamData);
			UpdateChart(_formsPlot[1], data.Press, _pressStreamData);
			UpdateChart(_formsPlot[2], data.Flow, _flowStreamData);
		}

		// 전체 차트 초기화 및 스트림데이터 세팅
		public void InitAllCharts(List<SensorTypeIdDto> sensorTypes)
		{
			_tempStreamData = new List<(string, DataStreamer)>();
			_pressStreamData = new List<(string, DataStreamer)>();
			_flowStreamData = new List<(string, DataStreamer)>();

			InitChart(_formsPlot[0], "FDC Real-Time Monitor(TEMP)",
				sensorTypes.Where(x => x.sensorType == "TEMP")
						   .Select(x => x.sensorId).ToList(),
				_tempStreamData);

			InitChart(_formsPlot[1], "FDC Real-Time Monitor(PRESSURE)",
				sensorTypes.Where(x => x.sensorType == "PRESSURE")
						   .Select(x => x.sensorId).ToList(),
				_pressStreamData);

			InitChart(_formsPlot[2], "FDC Real-Time Monitor(FLOW)",
				sensorTypes.Where(x => x.sensorType == "FLOW")
						   .Select(x => x.sensorId).ToList(),
				_flowStreamData);
		}

		// 차트 초기화 처리
		private void InitChart(FormsPlot chart, string title,
			List<string> sensorIds, List<(string, DataStreamer)> streamData)
		{
			chart.Reset();
			chart.Plot.Title(title);
			chart.Plot.XLabel("Time");
			chart.Plot.YLabel("Sensor Value");

			foreach (string sensorId in sensorIds)
			{
				DataStreamer streamer = chart.Plot.Add.DataStreamer(100);
				streamer.LegendText = sensorId;
				streamData.Add((sensorId, streamer));
			}

			chart.Plot.Axes.AutoScale();
			chart.Plot.ShowLegend();
			chart.Refresh();
		}

		// 차트 업데이트
		private void UpdateChart(FormsPlot chart,
			Dictionary<string, List<double>> datas,
			List<(string, DataStreamer)> streamData)
		{
			if (chart.InvokeRequired)
			{
				// UI 스레드 밖에서 호출된 경우: 작업을 큐에 넣고 즉시 리턴합니다 (Non-blocking)
				try
				{
					chart.BeginInvoke(new Action(() =>
					{
						// 실제 UI 스레드에서 실행될 시점에 컨트롤 상태 확인
						if (!chart.IsDisposed && chart.IsHandleCreated)
							PerformChartUpdate(chart, datas, streamData);
					}));
				}
				catch (Exception ex)
				{
					LogHelper.Error("BeginInvoke 호출 중 오류 발생", ex);
				}
				return;
			}
			// IProgress를 통해 호출되므로 이미 UI 스레드임이 보장되지만, 
			// 컨트롤의 생존 여부는 여전히 확인해야 합니다.
			if (chart == null || chart.IsDisposed || !chart.IsHandleCreated) return;

			// 이미 UI 스레드인 경우: 즉시 실행
			PerformChartUpdate(chart, datas, streamData);
		}

		/// <summary>
		/// 실제 차트 업데이트 로직을 수행하는 헬퍼 메서드
		/// </summary>
		private void PerformChartUpdate(FormsPlot chart,
			Dictionary<string, List<double>> datas,
			List<(string, DataStreamer)> streamData)
		{
			foreach (var (sensorId, streamer) in streamData)
			{
				if (datas.TryGetValue(sensorId, out List<double> values))
				{
					foreach (double value in values)
						streamer.Add(value);
				}
			}

			chart.Refresh();
		}

		// LOT 상세정보 조회
		public async Task<string> GetDetailInfo(int lotKey)
		{
			string retString = "";

			try
			{
				LotDetailDto lotDetail = await _controller.GetLotDetail(lotKey);

				retString = $"Lot ID: {lotDetail.lotId}\r\n" +
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
			catch (Exception ex)
			{
				OnError?.Invoke(this, $"상세정보 처리 오류 : lotKey: {lotKey} / " + ex.Message);
				retString = "";
			}

			return retString;
			
		}

	}
}
