using SkFdc1.Models;
using SkFdc1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//사용자의 요청을 받아 서비스를 호출하고 화면에 전달합니다. (WinForms라면 Form 클래스에 해당)
namespace SkFdc1.Controllers
{
    public class SensorController
    {
        private readonly ISensorService _sensorService;

        // 의존성 주입(DI)을 통해 서비스를 가져온다
        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;            
        }

        // 폼에서 호출할 메서드
        public async Task<List<SensorDto>> DisplaySensorList()
        {
            //서비스에 로직 처리를 맡김
            var result = await _sensorService.GetProcessSensorDataAsync();
            return result;
        }

        public async Task<SensorDto> DisplaySensorOne(string sensorId)
        {
            var result = await _sensorService.GetProcessSensorOneDataAsync(sensorId);
            return result;
        }

        public async Task<List<SensorValuesDto>> DisplaySensorValues(string lotId, string sensorType)
        {
            var result = await _sensorService.GetProcessSensorValuesAsync(lotId, sensorType);
            return result;
        }

        public async Task<List<SensorTypeDto>> DisplaySensorType()
        {
            var result = await _sensorService.GetProcessSensorTypesAsync();
            return result;            
        }
    }
}
