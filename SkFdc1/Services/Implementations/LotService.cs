using SkFdc1.Models;
using SkFdc1.Repositories.Implementations;
using SkFdc1.Repositories.Interfaces;
using SkFdc1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Services.Implementations
{
	internal class LotService : ILotService
	{
		private readonly ILotRepository _lotRepository;

		public LotService(ILotRepository lotRepository)
		{
			_lotRepository = lotRepository;
		}

		public async Task<LotDetailDto> GetProcessLotDetail(string lotId)
		{
			//var data = await _sensorRepository.GetSensorsAsync();
			// 실무 로직 예: 데이터가 없으면 기본값 처리하거나 특정 상태 가공
			//if (data != null && data.Status == "WAITING")
			//{
			//    data.Status = "대기중";
			//}

			LotDetailDto data = await _lotRepository.GetLotDetail(lotId);

			return data;
		}

		public async Task<List<LotViewDto>> GetProcessLotViewList()
		{
			List<LotViewDto> data = await _lotRepository.GetLotViewList();
			return data;
		}

		public async Task<List<SensorDataDto>> GetProcessSensorData(string lotId, string sensorId, int lastDataId)
		{
			List<SensorDataDto> data = await _lotRepository.GetSensorData(lotId, sensorId, lastDataId);
			return data;
		}

		public async Task<List<SensorTypeIdDto>> GetProcessSensorTypeIds(string lotId)
		{
			var data = await _lotRepository.GetSensorTypeIds(lotId);
			return data;
		}
	}
}
