using SkFdc1.Forms.Manage;
using SkFdc1.Forms.Status;
using SkFdc1.Forms.Summary;
using SkFdc1.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkFdc1
{
	public partial class frmFdcMain : Form
	{
		private readonly LotController _lotController;

		public frmFdcMain(LotController lotController)
		{
			InitializeComponent();

			_lotController = lotController;
		}

		#region private

		private void OpenForm(Form form)
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

		#endregion

		#region event

		private void mnuStatusLive_Click(object sender, EventArgs e)
			=> OpenForm(new frmStatusLive(_lotController));

		private void mnuSummaryTotal_Click(object sender, EventArgs e)
			=> OpenForm(new frmSummaryTotal());

		private void mnuSummarySensor_Click(object sender, EventArgs e)
			=> OpenForm(new frmSummarySensor());

		private void mnuManageArea_Click(object sender, EventArgs e)
			=> OpenForm(new frmManageArea());

		private void mnuManageEqp_Click(object sender, EventArgs e)
			=> OpenForm(new frmManageEqp());

		private void mnuManageLot_Click(object sender, EventArgs e)
			=> OpenForm(new frmManageLot());

		private void mnuManageSensor_Click(object sender, EventArgs e)
			=> OpenForm(new frmManageSensor());

		#endregion
	}
}
