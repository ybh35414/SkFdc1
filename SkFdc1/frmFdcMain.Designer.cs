namespace SkFdc1
{
	partial class frmFdcMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			mnuStatus = new ToolStripMenuItem();
			mnuStatusLive = new ToolStripMenuItem();
			mnuSummary = new ToolStripMenuItem();
			mnuSummaryTotal = new ToolStripMenuItem();
			mnuSummarySensor = new ToolStripMenuItem();
			mnuManage = new ToolStripMenuItem();
			mnuManageArea = new ToolStripMenuItem();
			mnuManageEqp = new ToolStripMenuItem();
			mnuManageLot = new ToolStripMenuItem();
			mnuManageSensor = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { mnuStatus, mnuSummary, mnuManage });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1504, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// mnuStatus
			// 
			mnuStatus.DropDownItems.AddRange(new ToolStripItem[] { mnuStatusLive });
			mnuStatus.Name = "mnuStatus";
			mnuStatus.Size = new Size(43, 20);
			mnuStatus.Text = "현황";
			// 
			// mnuStatusLive
			// 
			mnuStatusLive.Name = "mnuStatusLive";
			mnuStatusLive.Size = new Size(180, 22);
			mnuStatusLive.Text = "실시간 그래프";
			mnuStatusLive.Click += mnuStatusLive_Click;
			// 
			// mnuSummary
			// 
			mnuSummary.DropDownItems.AddRange(new ToolStripItem[] { mnuSummaryTotal, mnuSummarySensor });
			mnuSummary.Name = "mnuSummary";
			mnuSummary.Size = new Size(43, 20);
			mnuSummary.Text = "통계";
			// 
			// mnuSummaryTotal
			// 
			mnuSummaryTotal.Name = "mnuSummaryTotal";
			mnuSummaryTotal.Size = new Size(138, 22);
			mnuSummaryTotal.Text = "전체 통계";
			mnuSummaryTotal.Click += mnuSummaryTotal_Click;
			// 
			// mnuSummarySensor
			// 
			mnuSummarySensor.Name = "mnuSummarySensor";
			mnuSummarySensor.Size = new Size(138, 22);
			mnuSummarySensor.Text = "센서값 조회";
			mnuSummarySensor.Click += mnuSummarySensor_Click;
			// 
			// mnuManage
			// 
			mnuManage.DropDownItems.AddRange(new ToolStripItem[] { mnuManageArea, mnuManageEqp, mnuManageLot, mnuManageSensor });
			mnuManage.Name = "mnuManage";
			mnuManage.Size = new Size(43, 20);
			mnuManage.Text = "관리";
			// 
			// mnuManageArea
			// 
			mnuManageArea.Name = "mnuManageArea";
			mnuManageArea.Size = new Size(132, 22);
			mnuManageArea.Text = "Area";
			mnuManageArea.Click += mnuManageArea_Click;
			// 
			// mnuManageEqp
			// 
			mnuManageEqp.Name = "mnuManageEqp";
			mnuManageEqp.Size = new Size(132, 22);
			mnuManageEqp.Text = "Equipment";
			mnuManageEqp.Click += mnuManageEqp_Click;
			// 
			// mnuManageLot
			// 
			mnuManageLot.Name = "mnuManageLot";
			mnuManageLot.Size = new Size(132, 22);
			mnuManageLot.Text = "Lot";
			mnuManageLot.Click += mnuManageLot_Click;
			// 
			// mnuManageSensor
			// 
			mnuManageSensor.Name = "mnuManageSensor";
			mnuManageSensor.Size = new Size(132, 22);
			mnuManageSensor.Text = "Sensor";
			mnuManageSensor.Click += mnuManageSensor_Click;
			// 
			// frmFdcMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1504, 966);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
			Name = "frmFdcMain";
			Text = "frmFdcMain";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem mnuStatus;
		private ToolStripMenuItem mnuStatusLive;
		private ToolStripMenuItem mnuSummary;
		private ToolStripMenuItem mnuSummaryTotal;
		private ToolStripMenuItem mnuSummarySensor;
		private ToolStripMenuItem mnuManage;
		private ToolStripMenuItem mnuManageArea;
		private ToolStripMenuItem mnuManageEqp;
		private ToolStripMenuItem mnuManageLot;
		private ToolStripMenuItem mnuManageSensor;
	}
}