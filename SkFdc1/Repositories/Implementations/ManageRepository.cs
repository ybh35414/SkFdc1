using Microsoft.VisualBasic;
using SkFdc1.Common;
using SkFdc1.Models;
using SkFdc1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Repositories.Implementations
{
	public class ManageRepository : IManageRepository
	{
		private readonly ApiClient _apiClient;

		public ManageRepository(ApiClient apiClient)
		{
			_apiClient = apiClient;
		}

		#region Area
		public async Task<List<AreaListDto>> GetAreaList()
		{
			return await _apiClient.GetAsync<List<AreaListDto>>("area/list");
		}

		public async Task<AreaListDto> GetAreaById(int areaKey)
		{
			return await _apiClient.GetAsync<AreaListDto>($"area/detail/{areaKey}");
		}

		public async Task<String> SaveArea(AreaSaveDto dto)
		{
			return await _apiClient.PostAsync("area/save", dto);
		}
		#endregion



		#region Equip
		public async Task<List<EqpListDto>> GetEqpList(int areaKey)
		{
			return await _apiClient.GetAsync<List<EqpListDto>>($"eqp/list/{areaKey}");
		}

		public async Task<EqpListDto> GetEqpById(int eqpKey)
		{
			return await _apiClient.GetAsync<EqpListDto>($"eqp/detail/{eqpKey}");
		}

		public async Task<string> SaveEqp(EqpSaveDto dto)
		{
			return await _apiClient.PostAsync("eqp/save", dto);
		}
		#endregion

		#region LotStatus
		public async Task<List<LotStatusKeyListDto>> GetStatusKeyList(int areaKey)
		{
			return await _apiClient.GetAsync<List<LotStatusKeyListDto>>($"lotStatus/list/{areaKey}");
		}

		public async Task<string> SaveLotStatus(LotStatusSaveRequest dto)
		{
			return await _apiClient.PostAsync("lotStatus/saveAll", dto);
		}

		#endregion

	}

}
