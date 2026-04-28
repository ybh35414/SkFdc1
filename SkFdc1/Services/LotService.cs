using SkFdc1.Common;
using SkFdc1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkFdc1.Services
{
	public class LotService
	{
		private readonly ApiClient _apiClient;

		public LotService()
		{
			_apiClient = new ApiClient();
		}

		public async Task<List<LotViewDto>> getLotViewList()
		{
			return await _apiClient.GetAsync<List<LotViewDto>>("lots/view");
		}

		public async Task<LotDetailDto> GetLotDetail(string lotId)
		{
			return await _apiClient.GetAsync<LotDetailDto>($"lot/detail/{lotId}");
		}

		public async Task<List<SensorDto>> GetSensorsAsync()
		{
			return await _apiClient.GetAsync<List<SensorDto>>("Sensors");
		}
		
	}
}
