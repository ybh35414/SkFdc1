using SkFdc1.Common;
using SkFdc1.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

		////public async Task<List<SensorDto>> GetSensorsAsync()
		////{
		////	return await _apiClient.GetAsync<List<SensorDto>>("sensor/view");
		////}

		//public async Task<(bool success, string message)> SaveSensorAsync(SensorDto dto)
		//{
  //          //return await _apiClient.SaveSensorAsync(dto);

  //          // =========================================================
  //          // 1. 기본 검증 (Service 단에서 실무에서 하는 부분)
  //          // =========================================================

  //          // ✔ Null, 공백 체크
  //          if (string.IsNullOrWhiteSpace(dto.SensorID))
  //              return (false, "SENSOR_ID가 비어있습니다.");

  //          if (string.IsNullOrWhiteSpace(dto.EquipID))
  //              return (false, "EQUIP_ID가 비어있습니다.");

  //          // ✔ 길이 제한
  //          if (dto.SensorID.Length > 30)
  //              return (false, "SENSOR_ID는 최대 30자까지 입력 가능합니다.");

  //          // ✔ 영문+숫자 조합만 허용 (실무에서 많이 사용되는 패턴)
  //          if (!Regex.IsMatch(dto.SensorID, @"^[A-Za-z0-9_-]+$"))
  //              return (false, "SENSOR_ID는 영문/숫자/언더바/하이픈만 허용됩니다.");

  //          // ✔ SensorType 제한 (예: 실무에서 코드 정해진 경우)
  //          var allowedTypes = new[] { "TEMP", "PRESS", "FLOW", "HUMI" };
  //          if (!allowedTypes.Contains(dto.SensorType.ToUpper()))
  //              return (false, $"SENSOR_TYPE '{dto.SensorType}'는 허용되지 않습니다.");

  //          // =========================================================
  //          // 2. 서버에 중복 체크 API 호출 (실무에서 거의 필수)
  //          // =========================================================
  //          var exists = await _apiClient.CheckDuplicateAsync(dto.SensorID);
  //          if (exists)
  //              return (false, "이미 존재하는 Sensor iD 입니다.");

  //          // =========================================================
  //          // 3. 의사 트랜잭션(Pseudo Transaction)
  //          //    - 여러 API 호출을 하나의 '논리적' 트랜잭션처럼 묶기
  //          // =========================================================

  //          // 사전 저장 로그 생성(begin)
  //          var txId = await _apiClient.CreateTransactionLogAsync(dto);
  //          if(string.IsNullOrEmpty(txId))
  //          {
  //              return (false, "트랜잭션 초기화 실패");
  //          }
  //          try
  //          {
  //              //실제 저장
  //              var saveResult = await _apiClient.SaveSensorAsync(dto);
  //              if (!saveResult)
  //              {
  //                  //실패시 롤백요청
  //                  await _apiClient.RollbackTransactionAsync(txId);
  //                  return (false, "저장 중 오류가 발생하여 롤백되었습니다");
  //              }

  //              //트랜잭션 완료
  //              await _apiClient.CommitTransactionAsync(txId);
  //              return (true, "정상적으로 저장되었습니다");

  //          }
  //          catch (Exception)
  //          {
  //              await _apiClient.RollbackTransactionAsync(txId);
  //              return (false, "예외가 발생하여 롤백되었습니다");
  //          }

  //      }
    }
		public async Task<List<SensorDto>> GetSensorsAsync()
		{
			return await _apiClient.GetAsync<List<SensorDto>>("Sensors");
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
