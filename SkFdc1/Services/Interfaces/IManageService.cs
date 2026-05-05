using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Services.Interfaces
{
	public interface IManageService
	{
		#region Area
		// AreaList
		Task<List<AreaListDto>> GetProcessAreaList();
		// Area 정보
		Task<AreaListDto> GetProcessAreaById(int areaKey);
		// Area 저장
		Task<(bool success, string message)> SetProcessSaveArea(EqpSaveDto dto);
		#endregion


		#region Equip

		Task<List<EqpListDto>> GetProcessEqpList(int areaKey);
		Task<EqpListDto> GetProcessEqpById(int eqpKey);
		Task<(bool success, string message)> SetProcessSaveEqp(AreaSaveDto dto);

		#endregion

	}
}
