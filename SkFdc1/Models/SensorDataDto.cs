using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Models
{
	public class SensorDataDto
	{
		public string lotId { get; set; }
		public string status { get; set; }
		public string equipmentName { get; set; }
		public string areaName { get; set; }

		public string SensorId { get; set; }

		public List<double> Values { get; set; } = new();

		public Scatter Scatter { get; set; }
	}
}
