using System.Collections.Generic;

namespace SkFdc1.Models
{
	/// <summary>
	/// 차트 업데이트를 위해 UI로 전달할 데이터 패키지
	/// </summary>
	public class ChartUpdatePackage
	{
		public Dictionary<string, List<double>> Temp { get; set; } = new();
		public Dictionary<string, List<double>> Press { get; set; } = new();
		public Dictionary<string, List<double>> Flow { get; set; } = new();
	}
}
