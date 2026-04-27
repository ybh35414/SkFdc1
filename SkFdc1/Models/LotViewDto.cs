using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SkFdc1.Models
{
	public class LotViewDto
	{
		public string lotId { get; set; }
		public string status { get; set; }
		public string equipmentName { get; set; }
		public string areaName { get; set; }
	}
}
