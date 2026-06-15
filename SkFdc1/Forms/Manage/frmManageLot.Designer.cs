namespace SkFdc1.Forms.Manage
{
	partial class frmManageLot
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
			tableLayoutPanel1 = new TableLayoutPanel();
			panel2 = new Panel();
			btnAddRow = new Button();
			btnNew = new Button();
			btnSave = new Button();
			grdLot = new DataGridView();
			colProductId = new DataGridViewComboBoxColumn();
			colPrcId = new DataGridViewComboBoxColumn();
			colEqpId = new DataGridViewComboBoxColumn();
			colLotId = new DataGridViewTextBoxColumn();
			colStatus = new DataGridViewComboBoxColumn();
			colStartTme = new DataGridViewTextBoxColumn();
			colEndTime = new DataGridViewTextBoxColumn();
			colPriority = new DataGridViewComboBoxColumn();
			panel1 = new Panel();
			cboAreaName = new ComboBox();
			label2 = new Label();
			tableLayoutPanel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdLot).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel2, 0, 1);
			tableLayoutPanel1.Controls.Add(grdLot, 1, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
			tableLayoutPanel1.Size = new Size(956, 497);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.Controls.Add(btnAddRow);
			panel2.Controls.Add(btnNew);
			panel2.Controls.Add(btnSave);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 399);
			panel2.Name = "panel2";
			panel2.Size = new Size(179, 95);
			panel2.TabIndex = 2;
			// 
			// btnAddRow
			// 
			btnAddRow.Location = new Point(105, 6);
			btnAddRow.Name = "btnAddRow";
			btnAddRow.Size = new Size(67, 23);
			btnAddRow.TabIndex = 8;
			btnAddRow.Text = "행추가";
			btnAddRow.UseVisualStyleBackColor = true;
			btnAddRow.Click += btnAddRow_Click;
			// 
			// btnNew
			// 
			btnNew.Location = new Point(3, 63);
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(55, 23);
			btnNew.TabIndex = 1;
			btnNew.Text = "신규";
			btnNew.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(105, 63);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(67, 23);
			btnSave.TabIndex = 0;
			btnSave.Text = "저장";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// grdLot
			// 
			grdLot.AllowUserToAddRows = false;
			grdLot.BackgroundColor = Color.White;
			grdLot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdLot.Columns.AddRange(new DataGridViewColumn[] { colProductId, colPrcId, colEqpId, colLotId, colStatus, colStartTme, colEndTime, colPriority });
			grdLot.Dock = DockStyle.Fill;
			grdLot.Location = new Point(188, 3);
			grdLot.Name = "grdLot";
			tableLayoutPanel1.SetRowSpan(grdLot, 2);
			grdLot.Size = new Size(765, 491);
			grdLot.TabIndex = 0;
			// 
			// colProductId
			// 
			colProductId.HeaderText = "Product ID";
			colProductId.Name = "colProductId";
			colProductId.Resizable = DataGridViewTriState.True;
			colProductId.SortMode = DataGridViewColumnSortMode.Automatic;
			colProductId.Width = 80;
			// 
			// colPrcId
			// 
			colPrcId.HeaderText = "Process ID";
			colPrcId.Name = "colPrcId";
			colPrcId.Resizable = DataGridViewTriState.True;
			colPrcId.SortMode = DataGridViewColumnSortMode.Automatic;
			colPrcId.Width = 80;
			// 
			// colEqpId
			// 
			colEqpId.HeaderText = "Equipment ID";
			colEqpId.Name = "colEqpId";
			colEqpId.Resizable = DataGridViewTriState.True;
			colEqpId.SortMode = DataGridViewColumnSortMode.Automatic;
			colEqpId.Width = 80;
			// 
			// colLotId
			// 
			colLotId.HeaderText = "Lot Id";
			colLotId.Name = "colLotId";
			// 
			// colStatus
			// 
			colStatus.HeaderText = "Status";
			colStatus.Name = "colStatus";
			colStatus.Resizable = DataGridViewTriState.True;
			colStatus.SortMode = DataGridViewColumnSortMode.Automatic;
			colStatus.Width = 70;
			// 
			// colStartTme
			// 
			colStartTme.HeaderText = "StartTme";
			colStartTme.Name = "colStartTme";
			colStartTme.Width = 120;
			// 
			// colEndTime
			// 
			colEndTime.HeaderText = "Endtime";
			colEndTime.Name = "colEndTime";
			colEndTime.Width = 120;
			// 
			// colPriority
			// 
			colPriority.HeaderText = "Priority";
			colPriority.Name = "colPriority";
			colPriority.Width = 70;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.Controls.Add(cboAreaName);
			panel1.Controls.Add(label2);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(179, 390);
			panel1.TabIndex = 1;
			// 
			// cboAreaName
			// 
			cboAreaName.DropDownStyle = ComboBoxStyle.DropDownList;
			cboAreaName.FormattingEnabled = true;
			cboAreaName.Location = new Point(8, 34);
			cboAreaName.Name = "cboAreaName";
			cboAreaName.Size = new Size(163, 23);
			cboAreaName.TabIndex = 6;
			cboAreaName.SelectedIndexChanged += cboAreaName_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 9);
			label2.Name = "label2";
			label2.Size = new Size(67, 15);
			label2.TabIndex = 3;
			label2.Text = "Area Name";
			// 
			// frmManageLot
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(956, 497);
			Controls.Add(tableLayoutPanel1);
			Name = "frmManageLot";
			Text = "frmManageLot";
			Load += frmManageLot_Load;
			tableLayoutPanel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)grdLot).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel2;
		private Button btnNew;
		private Button btnSave;
		private DataGridView grdLot;
		private Panel panel1;
		private ComboBox cboAreaName;
		private Label label2;
		private DataGridViewComboBoxColumn colProductId;
		private DataGridViewComboBoxColumn colPrcId;
		private DataGridViewComboBoxColumn colEqpId;
		private DataGridViewTextBoxColumn colLotId;
		private DataGridViewComboBoxColumn colStatus;
		private DataGridViewTextBoxColumn colStartTme;
		private DataGridViewTextBoxColumn colEndTime;
		private DataGridViewComboBoxColumn colPriority;
		private Button btnAddRow;
	}
}