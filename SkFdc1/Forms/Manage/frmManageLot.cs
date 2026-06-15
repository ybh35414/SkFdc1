using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Enum;
using SkFdc1.Models;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace SkFdc1.Forms.Manage
{
	public partial class frmManageLot : Form
	{
		private readonly ManageController _controller;
		private readonly frmFdcMain _mainForm;
		private bool mLoadEnd = false;
		private int _curEqpKey;

		public frmManageLot(frmFdcMain frmFdcMain, ManageController manageController)
		{
			InitializeComponent();

			grdLot.DataError += (s, e) => { };

			_controller = manageController;
			_mainForm = frmFdcMain;
		}

		#region 이벤트

		private void frmManageLot_Load(object sender, EventArgs e)
		{
			InitGrd();

			mLoadEnd = true;
		}

		private void btnAddRow_Click(object sender, EventArgs e)
		{
			grdLot.Rows.Add();
		}

		private async void cboAreaName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboAreaName.SelectedValue == null || !mLoadEnd)
				return;

			int selectAreaKey = ComboBoxHelper.GetValueI(cboAreaName);
			List<LotStatusKeyListDto> listStatus = await _controller.GetStatusKeyList(selectAreaKey);

			SetGridCombo(listStatus);
		}

		#endregion 이벤트

		#region 내부함수

		// 그리드 초기화
		private async void InitGrd()
		{
			//colPriority
			DataGridViewComboBoxColumn col;

			col = (DataGridViewComboBoxColumn)grdLot.Columns["colPriority"];
			col.Items.Clear();
			col.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

			col = (DataGridViewComboBoxColumn)grdLot.Columns["colStatus"];
			col.Items.Clear();
			col.Items.AddRange(new string[] { "RUN", "IDLE", "STOP" });

			// Area 콤보박스
			List<AreaListDto> list = await _controller.GetAreaList();
			ComboBoxHelper.Bind(cboAreaName,
				list.Select(x => new ComboItemI(x.areaKey, $"{x.areaName}({x.areaId})")).ToList()
			);
		}

		private void SetGridComboItem(DataGridViewComboBoxColumn col, List<ComboItem> items)
		{
			col.DataSource = items;
			col.DisplayMember = "Text";
			col.ValueMember = "Value";
		}

		/// <summary>
		/// 그리드 콤보 설정
		/// </summary>
		/// <param name="listStatus"></param>
		private void SetGridCombo(List<LotStatusKeyListDto> listStatus)
		{
			string[] types = new string[] { "PRODUCT", "PROCESS", "EQUIPMENT" };
			List<ComboItem> cboItem;
			int idx = 0;

			foreach (string type in types)
			{
				cboItem = listStatus
					.Where(x => x.keyType == type)
					.Select(x => new ComboItem(x.keyValue, x.keyId)).ToList();
				cboItem.Insert(0, new ComboItem("", "")); // 빈 항목 추가

				DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)grdLot.Columns[idx];
				SetGridComboItem(col, cboItem);

				idx++;
			}
		}

		#endregion 내부함수

		private int GetInt(object value)
		{
			return int.TryParse(value?.ToString(), out int result) ? result : 0;
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{

			// 데이터 생성
			List<LotStatusSaveDto> list = new();
			foreach (DataGridViewRow row in grdLot.Rows)
			{
				if (row.IsNewRow) continue;

				list.Add(new LotStatusSaveDto
				{
					lotKey = GetInt(row.Cells["colLotId"].Value), // 그냥 수동으로..
					productKey = GetInt(row.Cells["colProductId"].Value),
					processKey = GetInt(row.Cells["colPrcId"].Value),
					eqpKey = GetInt(row.Cells["colEqpId"].Value),
					lotId = row.Cells["colLotId"].Value?.ToString() ?? "",
					status = row.Cells["colStatus"].Value?.ToString() ?? "",
					priority = row.Cells["colPriority"].Value?.ToString() ?? "",
					rowState = "U" // 그냥 수동.. U D
				});
			}


			// 저장 처리
			(bool success, string message) = await _controller.SaveLotStatus(list);

			if (success)
			{
				MessageHelper.ShowSaveSuccess();
			}
			else
			{
				MessageHelper.ShowError(message);
				LogHelper.Warn($"Area 저장 실패 - {message}");
			}
		}
	}
}