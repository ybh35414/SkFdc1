using SkFdc1.Models;
using SkFdc1.Services;
using SkFdc1.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkFdc1.Controllers
{
	public class LotController
	{
		// 버전 1.1
		private readonly ILotService _lotService;

		public LotController(ILotService lotService)
		{
			_lotService = lotService;
		}

		public async Task<List<LotViewDto>> GetLotViewList()
		{
			List<LotViewDto> lots = await _lotService.GetProcessLotViewList();
			return lots;
		}

		public async Task<LotDetailDto> GetLotDetail(string lotId)
		{
			LotDetailDto dtl = await _lotService.GetProcessLotDetail(lotId);
			return dtl;	
		}

		public async Task<List<SensorDataDto>> GetSensorData(string lotId, string sensorId, int lastDataId)
		{
			List<SensorDataDto> sensorData = await _lotService.GetProcessSensorData(lotId, sensorId, lastDataId);
			return sensorData;
		}

		public async Task<List<SensorTypeIdDto>> GetSensorTypeIds(string lotId)
		{
			List<SensorTypeIdDto> sensorData = await _lotService.GetProcessSensorTypeIds(lotId);
			return sensorData;
		}
	}
}
