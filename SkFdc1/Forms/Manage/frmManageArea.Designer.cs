namespace SkFdc1.Forms.Manage
{
	partial class frmManageArea
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
			grdArea = new DataGridView();
			panel1 = new Panel();
			label2 = new Label();
			label1 = new Label();
			txtAreaName = new TextBox();
			txtAreaId = new TextBox();
			colAreaKey = new DataGridViewTextBoxColumn();
			colAreaId = new DataGridViewTextBoxColumn();
			colAreaName = new DataGridViewTextBoxColumn();
			colEqpCount = new DataGridViewTextBoxColumn();
			colSensorCount = new DataGridViewTextBoxColumn();
			tableLayoutPanel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdArea).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel2, 0, 1);
			tableLayoutPanel1.Controls.Add(grdArea, 1, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			tableLayoutPanel1.Size = new Size(616, 531);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.Controls.Add(btnNew);
			panel2.Controls.Add(btnSave);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 484);
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
			// grdArea
			// 
			grdArea.BackgroundColor = Color.White;
			grdArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdArea.Columns.AddRange(new DataGridViewColumn[] { colAreaKey, colAreaId, colAreaName, colEqpCount, colSensorCount });
			grdArea.Dock = DockStyle.Fill;
			grdArea.Location = new Point(188, 3);
			grdArea.Name = "grdArea";
			tableLayoutPanel1.SetRowSpan(grdArea, 2);
			grdArea.Size = new Size(425, 525);
			grdArea.TabIndex = 0;
			grdArea.CellClick += grdArea_CellClick;
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(txtAreaName);
			panel1.Controls.Add(txtAreaId);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(179, 475);
			panel1.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 71);
			label2.Name = "label2";
			label2.Size = new Size(67, 15);
			label2.TabIndex = 3;
			label2.Text = "Area Name";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 16);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 2;
			label1.Text = "Area ID";
			// 
			// txtAreaName
			// 
			txtAreaName.BorderStyle = BorderStyle.FixedSingle;
			txtAreaName.Location = new Point(9, 94);
			txtAreaName.Name = "txtAreaName";
			txtAreaName.Size = new Size(163, 23);
			txtAreaName.TabIndex = 1;
			// 
			// txtAreaId
			// 
			txtAreaId.BorderStyle = BorderStyle.FixedSingle;
			txtAreaId.Location = new Point(9, 39);
			txtAreaId.Name = "txtAreaId";
			txtAreaId.Size = new Size(163, 23);
			txtAreaId.TabIndex = 0;
			// 
			// colAreaKey
			// 
			colAreaKey.HeaderText = "areaKey";
			colAreaKey.Name = "colAreaKey";
			colAreaKey.Visible = false;
			// 
			// colAreaId
			// 
			colAreaId.HeaderText = "Area ID";
			colAreaId.Name = "colAreaId";
			// 
			// colAreaName
			// 
			colAreaName.HeaderText = "Area Name";
			colAreaName.Name = "colAreaName";
			colAreaName.Width = 120;
			// 
			// colEqpCount
			// 
			colEqpCount.HeaderText = "Equipment Count";
			colEqpCount.Name = "colEqpCount";
			colEqpCount.Width = 80;
			// 
			// colSensorCount
			// 
			colSensorCount.HeaderText = "Sensor Count";
			colSensorCount.Name = "colSensorCount";
			colSensorCount.Width = 80;
			// 
			// frmManageArea
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(616, 531);
			Controls.Add(tableLayoutPanel1);
			Name = "frmManageArea";
			Text = "Area 관리";
			Load += frmManageArea_Load;
			tableLayoutPanel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)grdArea).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private DataGridView grdArea;
		private Panel panel2;
		private Panel panel1;
		private Button btnSave;
		private Label label2;
		private Label label1;
		private TextBox txtAreaName;
		private TextBox txtAreaId;
		private Button btnNew;
		private DataGridViewTextBoxColumn colAreaKey;
		private DataGridViewTextBoxColumn colAreaId;
		private DataGridViewTextBoxColumn colAreaName;
		private DataGridViewTextBoxColumn colEqpCount;
		private DataGridViewTextBoxColumn colSensorCount;
	}
}