using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//비즈니스 로직을 수행할 규칙을 정의
namespace SkFdc1.Services.Interfaces
{
    public interface ISensorService
    {
        Task<List<SensorDto>> GetProcessSensorDataAsync();
        Task<SensorDto> GetProcessSensorOneDataAsync(string sensorId);
        Task<List<SensorValuesDto>> GetProcessSensorValuesAsync(string lotId, string sensorType);
        Task<List<SensorTypeDto>> GetProcessSensorTypesAsync();

   
    }
}
