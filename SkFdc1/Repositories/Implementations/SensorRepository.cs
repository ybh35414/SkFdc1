using SkFdc1.Common;
using SkFdc1.Models;
using SkFdc1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkFdc1.Repositories.Implementations
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApiClient _apiClient; // 공통 API 클라이언트 가정

        public SensorRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }        

        //sensor list
        public async Task<List<SensorDto>> GetSensorsAsync()
        {
            //return await _apiClient.GetAsync<List<SensorDto>>("sensor/view");
            return await _apiClient.GetAsync<List<SensorDto>>("sensor/view");
        }

        //sensor one
        public async Task<SensorDto> GetSensorOneAsync(string sensorId)
        {
            return await _apiClient.GetAsync<SensorDto>($"sensor/view/{sensorId}");
        }

        //sensor 데이터
        public async Task<List<SensorValuesDto>> GetSensorValuesAsync(string lotId, string sensorType)
        {
            return await _apiClient.GetAsync<List<SensorValuesDto>>($"sensor/ViewValue?lotId={lotId}&sensorType={sensorType}");
        }

        //sensor 타입
        public async Task<List<SensorTypeDto>> GetSensorTypeAsync()
        {
            return await _apiClient.GetAsync<List<SensorTypeDto>>($"sensor/sensorType");
        }
    }
}
