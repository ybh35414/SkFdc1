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
	internal class StatusService : IStatusService
	{
		private readonly IStatusRepository _lotRepository;

		public StatusService(IStatusRepository lotRepository)
		{
			_lotRepository = lotRepository;
		}

		public async Task<LotDetailDto> GetProcessLotDetail(int lotKey)
		{
			//var data = await _sensorRepository.GetSensorsAsync();
			// 실무 로직 예: 데이터가 없으면 기본값 처리하거나 특정 상태 가공
			//if (data != null && data.Status == "WAITING")
			//{
			//    data.Status = "대기중";
			//}

			LotDetailDto data = await _lotRepository.GetLotDetail(lotKey);

			return data;
		}

		public async Task<List<LotViewDto>> GetProcessLotViewList()
		{
			List<LotViewDto> data = await _lotRepository.GetLotViewList();
			return data;
		}

		public async Task<List<SensorDataDto>> GetProcessSensorData(int lotKey, int sensorKey)
		{
			List<SensorDataDto> data = await _lotRepository.GetSensorData(lotKey, sensorKey);
			return data;
		}

		public async Task<List<SensorTypeIdDto>> GetProcessSensorTypeIds(int lotKey)
		{
			var data = await _lotRepository.GetSensorTypeIds(lotKey);
			return data;
		}
	}
}
