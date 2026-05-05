using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Services.Interfaces
{
	public interface IStatusService
	{
		// 센서 리스트 // Task<List<LotViewDto>> GetLotViewList();
		Task<List<LotViewDto>> GetProcessLotViewList();
		// 센서 상세정보
		Task<LotDetailDto> GetProcessLotDetail(int lotKey);
		// 센서 Value 처리
		Task<List<SensorDataDto>> GetProcessSensorData(int lotKey, int sensorKey);
		// 센서 타입 정보
		Task<List<SensorTypeIdDto>> GetProcessSensorTypeIds(int lotKey);
	}
}
