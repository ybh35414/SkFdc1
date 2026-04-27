using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Models
{
	public class LotDetailDto
	{
		public string lotId { get; set; }
		public string status { get; set; }
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		public int priority { get; set; }

		public string productName { get; set; }
		public string productType { get; set; }

		public string processName { get; set; }

		public string equipmentName { get; set; }
		public string equipmentStatus { get; set; }

		public string areaName { get; set; }
	}
}
