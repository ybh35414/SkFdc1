using ScottPlot.Plottables;
using ScottPlot.WinForms;
using SkFdc1.Controllers;
using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Services.Business.Lot
{
	public class SensorChartService
	{
		private readonly LotController _controller;
		private System.Windows.Forms.Timer? _timer;

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

		public SensorChartService(LotController controller)
		{
			_controller = controller;
		}

		public void SetChartObject(List<FormsPlot> formsPlot)
		{
			_formsPlot = formsPlot;
		}

		// 타이머 시작
		public void StartTimer(string lotId, int interval = 1000)
		{
			StopTimer(); // 기존 타이머 정리

			_timer = new System.Windows.Forms.Timer { Interval = interval };
			_timer.Tick += async (s, e) => await TimerTick(lotId);
			_timer.Start();
		}

		public void StopTimer()
		{
			_timer?.Stop();
			_timer?.Dispose();
			_timer = null;
		}

		// 센서 데이터 조회 및 타입별 분류
		public async Task FetchSensorData(string lotId)
		{
			TempValue = new Dictionary<string, List<double>>();
			PressValue = new Dictionary<string, List<double>>();
			FlowValue = new Dictionary<string, List<double>>();

			List<SensorTypeIdDto> sensorTypes = await _controller.GetSensorTypeIds(lotId);

			foreach (SensorTypeIdDto sensorTp in sensorTypes)
			{
				List<SensorDataDto> sensorData =
					await _controller.GetSensorData(lotId, sensorTp.sensorId, 0);

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

		private async Task TimerTick(string lotId)
		{
			_timer?.Stop();
			try
			{
				await FetchSensorData(lotId);

				// chartupdate
				UpdateChart(_formsPlot[0], TempValue, _tempStreamData);
				UpdateChart(_formsPlot[1], PressValue, _pressStreamData);
				UpdateChart(_formsPlot[2], FlowValue, _flowStreamData);
			}
			catch (Exception ex)
			{
				OnError?.Invoke(this, ex.Message);
			}
			finally
			{
				_timer?.Start();
			}
		}

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
				chart.Invoke(() => UpdateChart(chart, datas, streamData));
				return;
			}

			foreach (var (sensorId, streamer) in streamData)
			{
				if (!datas.ContainsKey(sensorId)) continue;
				foreach (double value in datas[sensorId])
					streamer.Add(value);
			}

			chart.Refresh();
		}

	}
}
