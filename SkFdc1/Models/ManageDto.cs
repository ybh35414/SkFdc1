using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Models
{

	#region Area
	public class AreaListDto
	{
		public int areaKey { get; set; }
		public string areaId { get; set; } = string.Empty;
		public string areaName { get; set; } = string.Empty;
		public int eqpCount { get; set; }
		public int sensorCount { get; set; }
	}

	public class AreaSaveDto
	{
		public int areaKey { get; set; }
		public string areaId { get; set; } = string.Empty;
		public string areaName { get; set; } = string.Empty;
		public string mode { get; set; } = string.Empty; // "INSERT" or "UPDATE"
	}
	#endregion

	#region Area
	public class EqpListDto
	{
		public int eqpKey { get; set; }
		public int areaKey { get; set; }
		public string eqpId { get; set; } = string.Empty;
		public string eqpName { get; set; } = string.Empty;
		public string status { get; set; } = string.Empty;
		public string model { get; set; } = string.Empty;
		public int sensorCount { get; set; }
	}

	public class EqpSaveDto
	{
		public int eqpKey { get; set; }
		public int areaKey { get; set; }
		public string eqpId { get; set; } = string.Empty;
		public string eqpName { get; set; } = string.Empty;
		public string status { get; set; } = string.Empty;
		public string model { get; set; } = string.Empty;
		public string mode { get; set; } = string.Empty; // "INSERT" or "UPDATE"
	}
	#endregion

	#region LotStatus
	public class LotStatusKeyListDto
	{
		public string keyType { get; set; } = string.Empty;
		public string keyValue { get; set; } = string.Empty;
		public string keyId { get; set; } = string.Empty;
	}

	public class LotStatusSaveDto
	{
		public int lotKey { get; set; }
		public int productKey { get; set; }
		public int processKey { get; set; }
		public int eqpKey { get; set; }
		public string lotId { get; set; } = string.Empty;
		public string status { get; set; } = string.Empty;
		public string priority { get; set; } = string.Empty;
		public string rowState { get; set; } = string.Empty;
	}

	public class LotStatusSaveRequest
	{
		[JsonProperty("list")] // JSON 직렬화 시 "list"라는 이름으로 매핑
		public List<LotStatusSaveDto> List { get; set; }
	}

	#endregion
}
