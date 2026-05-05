using SkFdc1.Models;
using SkFdc1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Controllers
{
	public class ManageController
	{
		private readonly IManageService _service;

		public ManageController(IManageService service)
		{
			_service = service;
		}

		#region Area
		public async Task<List<AreaListDto>> GetAreaList()
		{
			List<AreaListDto> data = await _service.GetProcessAreaList();
			return data;
		}

		public async Task<AreaListDto> GetAreaById(int areaKey)
		{
			AreaListDto data = await _service.GetProcessAreaById(areaKey);
			return data;
		}

		public async Task<(bool success, string message)> SaveArea(AreaSaveDto dto)
			=> await _service.SetProcessSaveEqp(dto);
		#endregion

		#region Eqp
		public async Task<List<EqpListDto>> GetEqpList(int areaKey)
		{
			List<EqpListDto> data = await _service.GetProcessEqpList(areaKey);
			return data;
		}

		public async Task<EqpListDto> GetEqpById(int eqpKey)
		{
			EqpListDto data = await _service.GetProcessEqpById(eqpKey);
			return data;
		}

		public async Task<(bool success, string message)> SaveEqp(EqpSaveDto dto)
			=> await _service.SetProcessSaveArea(dto);
		#endregion

	}
}
