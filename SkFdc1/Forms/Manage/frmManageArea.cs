using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Models;

namespace SkFdc1.Forms.Manage
{

	public partial class frmManageArea : Form
	{
		private readonly ManageController _controller;
		private readonly frmFdcMain _mainForm;
		private string _mode = "INSERT"; // 현재 저장 모드
		private int _curAreaKey;

		public frmManageArea(frmFdcMain frmFdcMain, ManageController manageController)
		{
			InitializeComponent();

			_controller = manageController;
			_mainForm = frmFdcMain;
		}

		#region 이벤트
		private async void frmManageArea_Load(object sender, EventArgs e)
		{
			await SetColumn();
			await LoadAreaList();

		}

		private void grdArea_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			var row = grdArea.Rows[e.RowIndex];
			txtAreaId.Text = row.Cells["colAreaId"].Value?.ToString() ?? "";
			txtAreaName.Text = row.Cells["colAreaName"].Value?.ToString() ?? "";

			_curAreaKey = Convert.ToInt32(row.Cells["colAreaKey"].Value);

			// 그리드 선택시 수정모드로 전환
			SetMode("UPDATE");

		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			Util.ClearTextBox(txtAreaId, txtAreaName);
			SetMode("INSERT");
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			// 유효성 체크
			if (!Util.ValidateRequired(true,
				(txtAreaId, "Area Id"),
				(txtAreaName, "Area Name")))
				return;

			AreaSaveDto dto = new AreaSaveDto
			{
				areaKey = _curAreaKey,
				areaId = txtAreaId.Text.Trim(),
				areaName = txtAreaName.Text.Trim(),
				mode = _mode
			};

			// 저장 처리
			(bool success, string message) = await _controller.SaveArea(dto);

			if (success)
			{
				MessageHelper.ShowSaveSuccess();
				await LoadAreaList(); // 다시 로드
				Util.ClearTextBox(txtAreaId, txtAreaName); // 텍스트박스 초기화
				SetMode("INSERT");
			}
			else
			{
				MessageHelper.ShowError(message);
				LogHelper.Warn($"Area 저장 실패 - {message}");
			}
	
		}

		#endregion

		#region 내부함수
		private async Task LoadAreaList()
		{
			List<AreaListDto> list = await _controller.GetAreaList();
			grdArea.DataSource = list;
		}

		private async Task SetColumn()
		{
			colAreaKey.DataPropertyName = "areaKey";
			colAreaId.DataPropertyName = "areaId";
			colAreaName.DataPropertyName = "areaName";
			colEqpCount.DataPropertyName = "eqpCount";
			colSensorCount.DataPropertyName = "sensorCount";
		}

		private void SetMode(string mode)
		{
			_mode = mode;

			// Insert 모드면 areaId 수정가능, update면 잠김
			//txtAreaId.ReadOnly = mode == "UPDATE";
		}


		#endregion

	}
}
