using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Enum;
using SkFdc1.Models;
using System.Data;

namespace SkFdc1.Forms.Manage
{
	public partial class frmManageEqp : Form
	{
		private readonly ManageController _controller;
		private readonly frmFdcMain _mainForm;
		private string _mode = "INSERT"; // 현재 저장 모드
		private bool mLoadEnd = false;
		private int _curEqpKey;

		public frmManageEqp(frmFdcMain frmFdcMain, ManageController manageController)
		{
			InitializeComponent();

			_controller = manageController;
			_mainForm = frmFdcMain;
		}

		#region 객체이벤트
		private async void btnSave_Click(object sender, EventArgs e)
		{
			// 유효성 체크
			if (!Util.ValidateRequired(true,
				(txtEqpId, "Equipment Id"),
				(txtEqpName, "Equipment Name")))
				return;

			EqpSaveDto dto = new EqpSaveDto
			{
				areaKey = Convert.ToInt32(cboAreaName.GetValue()),
				eqpKey = _curEqpKey,
				eqpId = txtEqpId.Text.Trim(),
				eqpName = txtEqpName.Text.Trim(),
				model = txtModel.Text.Trim(),
				status = cboStatus.Text.Trim(),
				mode = _mode
			};

			// 저장 처리
			(bool success, string message) = await _controller.SaveEqp(dto);

			if (success)
			{
				MessageHelper.ShowSaveSuccess();
				await LoadEqpList(); // 다시 로드
				Util.ClearTextBox(txtEqpId, txtEqpName, txtModel); // 텍스트박스 초기화
				SetMode("INSERT");
			}
			else
			{
				MessageHelper.ShowError(message);
				LogHelper.Warn($"Area 저장 실패 - {message}");
			}
		}

		private async void frmManageEqp_Load(object sender, EventArgs e)
		{
			await Init();
			await LoadArea();

			// 초기화 완료 후 1회만 실행
			mLoadEnd = true;
			await LoadEqpList();
		}

		private void grdEqp_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			ViewDetailInfo(e.RowIndex);
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			Util.ClearTextBox(txtEqpId, txtEqpName, txtModel);
			SetMode("INSERT");
		}

		private async void cboAreaName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboAreaName.SelectedValue == null || !mLoadEnd)
				return;

			await LoadEqpList();
		}

		#endregion


		#region 내부함수

		private void ViewDetailInfo(int row)
		{

			DataGridViewRow rowD = grdEqp.Rows[row];

			txtEqpId.Text = rowD.Cells["colEqpId"].Value?.ToString() ?? "";
			txtEqpName.Text = rowD.Cells["colEqpName"].Value?.ToString() ?? "";
			txtModel.Text = rowD.Cells["colEqpModel"].Value?.ToString() ?? "";
			ComboBoxHelper.SetEnumValue<EquipmentStatus>(cboStatus, rowD.Cells["colEqpStatus"].Value);

			_curEqpKey = Convert.ToInt32(rowD.Cells["colEqpKey"].Value.ToString());

			// 그리드 선택시 수정모드로 전환
			SetMode("UPDATE");

		}


		private async Task LoadArea()
		{
			List<AreaListDto> list = await _controller.GetAreaList();

			ComboBoxHelper.Bind(cboAreaName,
				list.Select(x => new ComboItemI(x.areaKey, $"{x.areaName}({x.areaId})")).ToList()
			);

		}

		private async Task LoadEqpList()
		{
			int areaKey = Convert.ToInt32(ComboBoxHelper.GetValue(cboAreaName));
			List<EqpListDto> list = await _controller.GetEqpList(areaKey);
			grdEqp.DataSource = list;

			if (list.Count > 0)
				ViewDetailInfo(0);
		}

		private async Task Init()
		{
			// 컬럼 정의
			colEqpKey.DataPropertyName = "eqpKey";
			colEqpId.DataPropertyName = "eqpId";
			colEqpName.DataPropertyName = "eqpName";
			colEqpStatus.DataPropertyName = "status";
			colEqpModel.DataPropertyName = "model";
			colSensorCount.DataPropertyName = "sensorCount";

			// Status List 처리
			ComboBoxHelper.BindEnum<EquipmentStatus>(cboStatus, false);
		}


		private void SetMode(string mode)
		{
			_mode = mode;

			// Insert 모드면 areaId 수정가능, update면 잠김
			//txtEqpId.ReadOnly = mode == "UPDATE";
		}


		#endregion

	}
}
