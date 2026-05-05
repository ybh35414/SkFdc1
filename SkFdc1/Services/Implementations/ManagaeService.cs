using Newtonsoft.Json;
using SkFdc1.Common;
using SkFdc1.Models;
using SkFdc1.Repositories.Interfaces;
using SkFdc1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkFdc1.Common.ApiClient;

namespace SkFdc1.Services.Implementations
{
	public class ManagaeService : IManageService
	{
		private readonly IManageRepository _repository;

		public ManagaeService(IManageRepository repository)
		{
			_repository = repository;
		}

		#region Area
		public async Task<List<AreaListDto>> GetProcessAreaList()
		{
			List<AreaListDto> data = await _repository.GetAreaList();
			return data;
		}

		public async Task<AreaListDto> GetProcessAreaById(int areaKey)
		{
			AreaListDto data = await _repository.GetAreaById(areaKey);
			return data;
		}

		public async Task<(bool success, string message)> SetProcessSaveEqp(AreaSaveDto dto)
		{
			try
			{
				string json = await _repository.SaveArea(dto);
				ApiPostResult result = JsonConvert.DeserializeObject<ApiPostResult>(json) ?? new ApiPostResult();
				return (result.Success, result.Message);

				//상단과 동일 소스
				//Dictionary<string, object>? result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
				//bool success = Convert.ToBoolean(result?["success"]);
				//string message = result?["message"]?.ToString() ?? "";
				//return (success, message);
			}
			catch (Exception ex)
			{
				LogHelper.Error("Area 저장 실패", ex);
				return (false, ex.Message);
			}
		}
		#endregion


		#region Equip
		public async Task<List<EqpListDto>> GetProcessEqpList(int areaKey)
		{
			List<EqpListDto> data = await _repository.GetEqpList(areaKey);
			return data;
		}

		public async Task<EqpListDto> GetProcessEqpById(int eqpKey)
		{
			EqpListDto data = await _repository.GetEqpById(eqpKey);
			return data;

		}

		public async Task<(bool success, string message)> SetProcessSaveArea(EqpSaveDto dto)
		{
			try
			{
				string json = await _repository.SaveEqp(dto);
				ApiPostResult result = JsonConvert.DeserializeObject<ApiPostResult>(json) ?? new ApiPostResult();
				return (result.Success, result.Message);
			}
			catch (Exception ex)
			{
				LogHelper.Error("Equip 저장 실패", ex);
				return (false, ex.Message);
			}
		}

		#endregion

	}
}
