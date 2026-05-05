namespace SkFdc1.Forms.Manage
{
	partial class frmManageEqp
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
			btnNew = new Button();
			btnSave = new Button();
			grdEqp = new DataGridView();
			panel1 = new Panel();
			label5 = new Label();
			txtModel = new TextBox();
			cboStatus = new ComboBox();
			label4 = new Label();
			cboAreaName = new ComboBox();
			label3 = new Label();
			txtEqpName = new TextBox();
			label2 = new Label();
			label1 = new Label();
			txtEqpId = new TextBox();
			colEqpKey = new DataGridViewTextBoxColumn();
			colEqpId = new DataGridViewTextBoxColumn();
			colEqpName = new DataGridViewTextBoxColumn();
			colEqpStatus = new DataGridViewTextBoxColumn();
			colEqpModel = new DataGridViewTextBoxColumn();
			colSensorCount = new DataGridViewTextBoxColumn();
			tableLayoutPanel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdEqp).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel2, 0, 1);
			tableLayoutPanel1.Controls.Add(grdEqp, 1, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			tableLayoutPanel1.Size = new Size(635, 532);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.Controls.Add(btnNew);
			panel2.Controls.Add(btnSave);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 485);
			panel2.Name = "panel2";
			panel2.Size = new Size(179, 44);
			panel2.TabIndex = 2;
			// 
			// btnNew
			// 
			btnNew.Location = new Point(3, 11);
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(55, 23);
			btnNew.TabIndex = 1;
			btnNew.Text = "신규";
			btnNew.UseVisualStyleBackColor = true;
			btnNew.Click += btnNew_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(105, 11);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(67, 23);
			btnSave.TabIndex = 0;
			btnSave.Text = "저장";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// grdEqp
			// 
			grdEqp.BackgroundColor = Color.White;
			grdEqp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdEqp.Columns.AddRange(new DataGridViewColumn[] { colEqpKey, colEqpId, colEqpName, colEqpStatus, colEqpModel, colSensorCount });
			grdEqp.Dock = DockStyle.Fill;
			grdEqp.Location = new Point(188, 3);
			grdEqp.Name = "grdEqp";
			tableLayoutPanel1.SetRowSpan(grdEqp, 2);
			grdEqp.Size = new Size(444, 526);
			grdEqp.TabIndex = 0;
			grdEqp.CellClick += grdEqp_CellClick;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.Controls.Add(label5);
			panel1.Controls.Add(txtModel);
			panel1.Controls.Add(cboStatus);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(cboAreaName);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(txtEqpName);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(txtEqpId);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(179, 476);
			panel1.TabIndex = 1;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(9, 219);
			label5.Name = "label5";
			label5.Size = new Size(41, 15);
			label5.TabIndex = 10;
			label5.Text = "Model";
			// 
			// txtModel
			// 
			txtModel.BorderStyle = BorderStyle.FixedSingle;
			txtModel.Location = new Point(8, 242);
			txtModel.Name = "txtModel";
			txtModel.Size = new Size(163, 23);
			txtModel.TabIndex = 9;
			// 
			// cboStatus
			// 
			cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			cboStatus.FormattingEnabled = true;
			cboStatus.Location = new Point(8, 190);
			cboStatus.Name = "cboStatus";
			cboStatus.Size = new Size(163, 23);
			cboStatus.TabIndex = 8;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(10, 165);
			label4.Name = "label4";
			label4.Size = new Size(40, 15);
			label4.TabIndex = 7;
			label4.Text = "Status";
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
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(9, 113);
			label3.Name = "label3";
			label3.Size = new Size(101, 15);
			label3.TabIndex = 5;
			label3.Text = "Equipment Name";
			// 
			// txtEqpName
			// 
			txtEqpName.BorderStyle = BorderStyle.FixedSingle;
			txtEqpName.Location = new Point(8, 136);
			txtEqpName.Name = "txtEqpName";
			txtEqpName.Size = new Size(163, 23);
			txtEqpName.TabIndex = 4;
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
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 62);
			label1.Name = "label1";
			label1.Size = new Size(81, 15);
			label1.TabIndex = 2;
			label1.Text = "Equipment ID";
			// 
			// txtEqpId
			// 
			txtEqpId.BorderStyle = BorderStyle.FixedSingle;
			txtEqpId.Location = new Point(8, 85);
			txtEqpId.Name = "txtEqpId";
			txtEqpId.Size = new Size(163, 23);
			txtEqpId.TabIndex = 0;
			// 
			// colEqpKey
			// 
			colEqpKey.HeaderText = "colEqpKey";
			colEqpKey.Name = "colEqpKey";
			colEqpKey.Visible = false;
			// 
			// colEqpId
			// 
			colEqpId.HeaderText = "Equipment ID";
			colEqpId.Name = "colEqpId";
			colEqpId.Width = 80;
			// 
			// colEqpName
			// 
			colEqpName.HeaderText = "Equipment Name";
			colEqpName.Name = "colEqpName";
			// 
			// colEqpStatus
			// 
			colEqpStatus.HeaderText = "Status";
			colEqpStatus.Name = "colEqpStatus";
			colEqpStatus.Width = 50;
			// 
			// colEqpModel
			// 
			colEqpModel.HeaderText = "Model Name";
			colEqpModel.Name = "colEqpModel";
			// 
			// colSensorCount
			// 
			colSensorCount.HeaderText = "Sensor Count";
			colSensorCount.Name = "colSensorCount";
			colSensorCount.Width = 70;
			// 
			// frmManageEqp
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(635, 532);
			Controls.Add(tableLayoutPanel1);
			Name = "frmManageEqp";
			Text = "Equipment 관리";
			Load += frmManageEqp_Load;
			tableLayoutPanel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)grdEqp).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel2;
		private Button btnNew;
		private Button btnSave;
		private DataGridView grdEqp;
		private Panel panel1;
		private Label label5;
		private TextBox txtModel;
		private ComboBox cboStatus;
		private Label label4;
		private ComboBox cboAreaName;
		private Label label3;
		private TextBox txtEqpName;
		private Label label2;
		private Label label1;
		private TextBox txtEqpId;
		private DataGridViewTextBoxColumn colEqpKey;
		private DataGridViewTextBoxColumn colEqpId;
		private DataGridViewTextBoxColumn colEqpName;
		private DataGridViewTextBoxColumn colEqpStatus;
		private DataGridViewTextBoxColumn colEqpModel;
		private DataGridViewTextBoxColumn colSensorCount;
	}
}