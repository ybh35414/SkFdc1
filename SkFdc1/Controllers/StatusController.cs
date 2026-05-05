using SkFdc1.Models;
using SkFdc1.Services;
using SkFdc1.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkFdc1.Controllers
{
	public class StatusController
	{
		// 버전 1.1
		private readonly IStatusService _lotService;

		public StatusController(IStatusService lotService)
		{
			_lotService = lotService;
		}

		public async Task<List<LotViewDto>> GetLotViewList()
		{
			List<LotViewDto> lots = await _lotService.GetProcessLotViewList();
			return lots;
		}

		public async Task<LotDetailDto> GetLotDetail(int lotKey)
		{
			LotDetailDto dtl = await _lotService.GetProcessLotDetail(lotKey);
			return dtl;	
		}

		public async Task<List<SensorDataDto>> GetSensorData(int lotKey, int sensorKey)
		{
			List<SensorDataDto> sensorData = await _lotService.GetProcessSensorData(lotKey, sensorKey);
			return sensorData;
		}

		public async Task<List<SensorTypeIdDto>> GetSensorTypeIds(int lotKey)
		{
			List<SensorTypeIdDto> sensorData = await _lotService.GetProcessSensorTypeIds(lotKey);
			return sensorData;
		}
	}
}
