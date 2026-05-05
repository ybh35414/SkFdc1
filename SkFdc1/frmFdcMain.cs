using SkFdc1.Forms.Manage;
using SkFdc1.Forms.Status;
using SkFdc1.Forms.Summary;
using SkFdc1.Controllers;

namespace SkFdc1
{
	public partial class frmFdcMain : Form
	{
		private readonly StatusController _lotController;
		private readonly ManageController _manageController;

		public frmFdcMain(StatusController lotController, ManageController manageController)
		{
			InitializeComponent();

			this._lotController = lotController;
			this._manageController = manageController;
		}

		#region private

		private void OpenMdi(Form form)
		{
			// 기존 폼 닫기
			foreach (Control ctrl in this.Controls)
				ctrl.Dispose();
			this.Controls.Clear();

			// 새 폼을 패널 안에 붙이기 (MDI 스타일)
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			this.Controls.Add(form);
			form.Show();
		}

		/// <summary>
		/// 팝업 처리 
		/// </summary>
		public void OpenPop(Form _this, Form frm, bool isDialog)
		{
			foreach (Form childForm in _this.OwnedForms)
			{
				if (frm.Name.Equals(childForm.Name))
				{
					childForm.BringToFront();
					break;
				}
			}
			frm.Owner = _this;
			frm.StartPosition = FormStartPosition.CenterParent;
			frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			frm.MaximizeBox = false;
			frm.MinimizeBox = false;

			if (isDialog)
				frm.ShowDialog();
			else
				frm.Show();
		}

		#endregion

		#region event

		private void mnuStatusLive_Click(object sender, EventArgs e)
			=> OpenMdi(new frmStatusLive(this, _lotController));

		private void mnuSummaryTotal_Click(object sender, EventArgs e)
			=> OpenMdi(new frmSummaryTotal());

		private void mnuSummarySensor_Click(object sender, EventArgs e)
			=> OpenMdi(new frmSummarySensor());

		private void mnuManageArea_Click(object sender, EventArgs e)
			=> OpenPop(this, new frmManageArea(this, _manageController), true);

		private void mnuManageEqp_Click(object sender, EventArgs e)
			=> OpenPop(this, new frmManageEqp(this, _manageController), true);

		private void mnuManageLot_Click(object sender, EventArgs e)
			=> OpenPop(this, new frmManageLot(), true);

		private void mnuManageSensor_Click(object sender, EventArgs e)
			=> OpenPop(this, new frmManageSensor(), true);

		#endregion
	}
}
