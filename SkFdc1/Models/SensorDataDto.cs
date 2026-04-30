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
		public int dataId { get; set; }
		public string eqpId { get; set; }
		public double sensorValue { get; set; }
	}
}
