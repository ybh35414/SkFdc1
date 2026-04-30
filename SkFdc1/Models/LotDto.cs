using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Models
{
	/// <summary>
	/// 선택한 LotId 상세 정보
	/// </summary>
	public class LotDetailDto
	{
		public string lotId { get; set; } = string.Empty;
		public string status { get; set; } = string.Empty;
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		public int priority { get; set; }

		public string productName { get; set; } = string.Empty;
		public string productType { get; set; } = string.Empty;

		public string processName { get; set; } = string.Empty;

		public string equipmentName { get; set; } = string.Empty;
		public string equipmentStatus { get; set; } = string.Empty;

		public string areaName { get; set; } = string.Empty;

		// empty변환
		public static readonly LotDetailDto Empty = new LotDetailDto
		{
			lotId = "",
			status = "",
			productName = "",
			productType = "",
			processName = "",
			equipmentName = "",
			equipmentStatus = "",
			areaName = "",
		};
	}

	/// <summary>
	/// Lot 상세 정보
	/// </summary>
	public class LotViewDto
	{
		public string lotId { get; set; } = string.Empty;
		public string status { get; set; } = string.Empty;
		public string equipmentName { get; set; } = string.Empty;
		public string areaName { get; set; } = string.Empty;

		public static readonly LotViewDto Empty = new LotViewDto
		{
			lotId = "",
			status = "",
			equipmentName = "",
			areaName = "",
		};
	}

	/// <summary>
	/// 센서값 정보
	/// </summary>
	public class SensorDataDto
	{
		public int dataId { get; set; }
		public string eqpId { get; set; } = string.Empty;
		public double sensorValue { get; set; }

		public static readonly SensorDataDto Empty = new SensorDataDto
		{
			eqpId = "",
		};
	}

	/// <summary>
	/// 타입별 센서 정보
	/// </summary>
	public class SensorTypeIdDto
	{
		public string areaName { get; set; } = string.Empty;
		public string eqpName { get; set; } = string.Empty;
		public string sensorId { get; set; } = string.Empty;
		public string sensorType { get; set; } = string.Empty;

		public static readonly SensorDataDto Empty = new SensorDataDto
		{
			eqpId = "",
		};

	}

}
