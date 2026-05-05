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
}
