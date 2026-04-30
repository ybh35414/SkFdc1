using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Repositories.Interfaces
{
	public interface ILotRepository
	{
		// 센서 리스트
		Task<List<LotViewDto>> GetLotViewList();
		// 센서 상세정보
		Task<LotDetailDto> GetLotDetail(string lotId);
		// 센서 Value 처리
		Task<List<SensorDataDto>> GetSensorData(string lotId, string sensorId, int lastDataId);
		// 센서 타입 정보
		Task<List<SensorTypeIdDto>> GetSensorTypeIds(string lotId);
	}
}
