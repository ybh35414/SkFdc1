using SkFdc1.Models;
using SkFdc1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkFdc1.Repositories.Interfaces;

//레포지토리를 호출하고, 필요시 데이터를 가공하거나 검증하는 비즈니스 로직을 담습니다.
//
namespace SkFdc1.Services.Implementations
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public async Task<List<SensorDto>> GetProcessSensorDataAsync()
        {
            var data = await  _sensorRepository.GetSensorsAsync();
            // 실무 로직 예: 데이터가 없으면 기본값 처리하거나 특정 상태 가공
            //if (data != null && data.Status == "WAITING")
            //{
            //    data.Status = "대기중";
            //}
            return data;
        }

        public async Task<SensorDto> GetProcessSensorOneDataAsync(string sensorId)
        {             
            if (string.IsNullOrEmpty(sensorId))
                return SensorDto.Empty; // null대신 빈 객체 반환
                //필수값인데 비어있으면 → 호출 자체가 잘못된 것 → 예외
                //throw new ArgumentException("SensorId는 필수 값입니다", nameof(sensorId));

            //데이터 조회
            var data = await _sensorRepository.GetSensorOneAsync(sensorId);
            
            //실무 데이터 가공
            if(data == null)
                return SensorDto.Empty; //null 대신 빈 객체 반환

            if(string.IsNullOrEmpty(data.Unit))
                data.Unit = "-";
            
            return data; // 조회 결과 없으면 null (이건 정상 케이스)
        }

        public async Task<List<SensorValuesDto>> GetProcessSensorValuesAsync(string lotId, string sensorType)
        {
            if (string.IsNullOrEmpty(lotId)) return new List<SensorValuesDto>();
            var data = await _sensorRepository.GetSensorValuesAsync(lotId, sensorType);
            return data;
        }

        public async Task<List<SensorTypeDto>> GetProcessSensorTypesAsync()
        {
            var data = await _sensorRepository.GetSensorTypeAsync();
            return data;
        }


    }
}
