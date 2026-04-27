using SkFdc1.Models;
using SkFdc1.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkFdc1.Controllers
{
	internal class LotController
	{
		// 버전 1.1

		private readonly LotService _service;

		public LotController()
		{
			_service = new LotService();
		}

		public async Task<List<LotViewDto>> GetLotViewList()
		{
			List<LotViewDto> lots = await _service.getLotViewList();
			return lots;
		}

		public async Task<LotDetailDto> GetLotDetail(string lotId)
		{
			LotDetailDto dtl = await _service.GetLotDetail(lotId);
			return dtl;	
		}
	}
}
