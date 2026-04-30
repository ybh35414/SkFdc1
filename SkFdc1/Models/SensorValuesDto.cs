using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Models
{
    public class SensorValuesDto
    {
        public string Sid { get; set; }
        public string Val1 { get; set; }
        public string Mestime { get; set; }
    }

    public class SensorTypeDto
    {
        public string SensorType { get; set; }
    }
}
