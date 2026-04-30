using SkFdc1.Common;
using SkFdc1.Models;
using SkFdc1.Repositories.Interfaces;

namespace SkFdc1.Repositories.Implementations
{
	internal class LotRepository : ILotRepository
	{
		private readonly ApiClient _apiClient; // 공통 API 클라이언트 가정

		public LotRepository(ApiClient apiClient)
		{
            _apiClient = apiClient;
		}

		public async Task<List<LotViewDto>> GetLotViewList()
		{
			return await _apiClient.GetAsync<List<LotViewDto>>("lots/view");
		}

		public async Task<LotDetailDto> GetLotDetail(string lotId)
		{
			return await _apiClient.GetAsync<LotDetailDto>($"lot/detail/{lotId}");
		}

		public async Task<List<SensorDataDto>> GetSensorData(string lotId, string sensorId, int lastDataId)
		{
			return await _apiClient.GetAsync<List<SensorDataDto>>($"lot/graph/values/{lotId}/{sensorId}/{lastDataId}");
		}

		public async Task<List<SensorTypeIdDto>> GetSensorTypeIds(string lotId)
		{
			return await _apiClient.GetAsync<List<SensorTypeIdDto>>($"lot/graph/sensor/{lotId}");
		}
	}
}
