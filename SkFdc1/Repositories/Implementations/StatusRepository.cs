using SkFdc1.Common;
using SkFdc1.Models;
using SkFdc1.Repositories.Interfaces;

namespace SkFdc1.Repositories.Implementations
{
	public class StatusRepository : IStatusRepository
	{
		private readonly ApiClient _apiClient; // 공통 API 클라이언트 가정

		public StatusRepository(ApiClient apiClient)
		{
            _apiClient = apiClient;
		}

		public async Task<List<LotViewDto>> GetLotViewList()
		{
			return await _apiClient.GetAsync<List<LotViewDto>>("lots/view");
		}

		public async Task<LotDetailDto> GetLotDetail(int lotKey)
		{
			return await _apiClient.GetAsync<LotDetailDto>($"lot/detail/{lotKey}");
		}

		public async Task<List<SensorDataDto>> GetSensorData(int lotKey, int sensorKey)
		{
			return await _apiClient.GetAsync<List<SensorDataDto>>($"lot/graph/values/{lotKey}/{sensorKey}");
		}

		public async Task<List<SensorTypeIdDto>> GetSensorTypeIds(int lotKey)
		{
			return await _apiClient.GetAsync<List<SensorTypeIdDto>>($"lot/graph/sensor/{lotKey}");
		}
	}
}
