using SkFdc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Repositories.Interfaces
{
	public interface IManageRepository
	{
		#region Area
		// AreaList
		Task<List<AreaListDto>> GetAreaList();
		// Area 정보
		Task<AreaListDto> GetAreaById(int areaKey);
		// Area 저장
		Task<String> SaveArea(AreaSaveDto dto);
		#endregion

		#region Eqp
		// AreaList
		Task<List<EqpListDto>> GetEqpList(int areaId);
		// Area 정보
		Task<EqpListDto> GetEqpById(int eqpKey);
		// Area 저장
		Task<String> SaveEqp(EqpSaveDto dto);
		#endregion

	}
}
