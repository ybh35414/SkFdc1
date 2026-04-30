namespace SkFdc1
{
	partial class MainForm
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
			splitContainer1 = new SplitContainer();
			grdList = new DataGridView();
			txtDtl = new TextBox();
			panel2 = new Panel();
			btnStop = new Button();
			tableLayoutPanel2 = new TableLayoutPanel();
			formsPlot3 = new ScottPlot.WinForms.FormsPlot();
			formsPlot2 = new ScottPlot.WinForms.FormsPlot();
			formsPlot1 = new ScottPlot.WinForms.FormsPlot();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdList).BeginInit();
			panel2.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 460F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
			tableLayoutPanel1.Controls.Add(panel2, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(1311, 821);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(3, 43);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(grdList);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(txtDtl);
			splitContainer1.Size = new Size(454, 775);
			splitContainer1.SplitterDistance = 421;
			splitContainer1.TabIndex = 3;
			// 
			// grdList
			// 
			grdList.BackgroundColor = Color.White;
			grdList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdList.Dock = DockStyle.Fill;
			grdList.GridColor = Color.White;
			grdList.Location = new Point(0, 0);
			grdList.Name = "grdList";
			grdList.Size = new Size(454, 421);
			grdList.TabIndex = 0;
			grdList.CellClick += grdList_CellClick;
			// 
			// txtDtl
			// 
			txtDtl.Dock = DockStyle.Fill;
			txtDtl.Font = new Font("맑은 고딕", 12F);
			txtDtl.Location = new Point(0, 0);
			txtDtl.Multiline = true;
			txtDtl.Name = "txtDtl";
			txtDtl.Size = new Size(454, 350);
			txtDtl.TabIndex = 1;
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			tableLayoutPanel1.SetColumnSpan(panel2, 2);
			panel2.Controls.Add(btnStop);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(1305, 34);
			panel2.TabIndex = 4;
			// 
			// btnStop
			// 
			btnStop.Location = new Point(379, 6);
			btnStop.Name = "btnStop";
			btnStop.Size = new Size(75, 23);
			btnStop.TabIndex = 1;
			btnStop.Text = "Stop";
			btnStop.UseVisualStyleBackColor = true;
			btnStop.Click += btnStop_Click;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel2.Controls.Add(formsPlot3, 0, 2);
			tableLayoutPanel2.Controls.Add(formsPlot2, 0, 1);
			tableLayoutPanel2.Controls.Add(formsPlot1, 0, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(463, 43);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 3;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.Size = new Size(845, 775);
			tableLayoutPanel2.TabIndex = 5;
			// 
			// formsPlot3
			// 
			formsPlot3.Dock = DockStyle.Fill;
			formsPlot3.Location = new Point(3, 519);
			formsPlot3.Name = "formsPlot3";
			formsPlot3.Size = new Size(839, 253);
			formsPlot3.TabIndex = 7;
			// 
			// formsPlot2
			// 
			formsPlot2.Dock = DockStyle.Fill;
			formsPlot2.Location = new Point(3, 261);
			formsPlot2.Name = "formsPlot2";
			formsPlot2.Size = new Size(839, 252);
			formsPlot2.TabIndex = 6;
			// 
			// formsPlot1
			// 
			formsPlot1.Dock = DockStyle.Fill;
			formsPlot1.Location = new Point(3, 3);
			formsPlot1.Name = "formsPlot1";
			formsPlot1.Size = new Size(839, 252);
			formsPlot1.TabIndex = 5;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1311, 821);
			Controls.Add(tableLayoutPanel1);
			Name = "MainForm";
			Text = "MainForm";
			Load += MainForm_Load;
			tableLayoutPanel1.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)grdList).EndInit();
			panel2.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private DataGridView grdList;
		private TextBox txtDtl;
		private SplitContainer splitContainer1;
		private Panel panel2;
		private Button btnStop;
		private ScottPlot.WinForms.FormsPlot formsPlot1;
		private TableLayoutPanel tableLayoutPanel2;
		private ScottPlot.WinForms.FormsPlot formsPlot3;
		private ScottPlot.WinForms.FormsPlot formsPlot2;
	}
}