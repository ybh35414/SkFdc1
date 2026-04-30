using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Services.Interfaces
{
	public interface ILotService
	{
		// 센서 리스트
		Task<List<LotViewDto>> GetProcessLotViewList();
		// 센서 상세정보
		Task<LotDetailDto> GetProcessLotDetail(string lotId);
		// 센서 Value 처리
		Task<List<SensorDataDto>> GetProcessSensorData(string lotId, string sensorId, int lastDataId);
		// 센서 타입 정보
		Task<List<SensorTypeIdDto>> GetProcessSensorTypeIds(string lotId);
	}
}
