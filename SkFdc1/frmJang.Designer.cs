namespace SkFdc1
{
    partial class frmJang
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
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            grdList = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSensorID = new TextBox();
            txtEquipID = new TextBox();
            txtSensorType = new TextBox();
            txtUnit = new TextBox();
            panel1 = new Panel();
            btnCancel = new Button();
            btnDel = new Button();
            btnSave = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            button2 = new Button();
            txtSID = new TextBox();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdList).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(19, 11);
            button1.Name = "button1";
            button1.Size = new Size(86, 34);
            button1.TabIndex = 3;
            button1.Text = "전체조회";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.0493832F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.9506149F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(810, 475);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.59347F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.40653F));
            tableLayoutPanel2.Controls.Add(grdList, 0, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 2);
            tableLayoutPanel2.Controls.Add(label3, 0, 3);
            tableLayoutPanel2.Controls.Add(label4, 0, 4);
            tableLayoutPanel2.Controls.Add(txtSensorID, 1, 1);
            tableLayoutPanel2.Controls.Add(txtEquipID, 1, 2);
            tableLayoutPanel2.Controls.Add(txtSensorType, 1, 3);
            tableLayoutPanel2.Controls.Add(txtUnit, 1, 4);
            tableLayoutPanel2.Controls.Add(panel1, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(133, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel1.SetRowSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(674, 469);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // grdList
            // 
            grdList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel2.SetColumnSpan(grdList, 2);
            grdList.Dock = DockStyle.Fill;
            grdList.Location = new Point(3, 3);
            grdList.Name = "grdList";
            grdList.Size = new Size(668, 228);
            grdList.TabIndex = 0;
            grdList.CellClick += grdList_CellClick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(136, 249);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 1;
            label1.Text = "SENSOR_ID";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(126, 295);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 1;
            label2.Text = "EQUIPMENT_ID";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(129, 341);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 1;
            label3.Text = "SENSOR_TYPE";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(154, 387);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 1;
            label4.Text = "UNIT";
            // 
            // txtSensorID
            // 
            txtSensorID.Anchor = AnchorStyles.None;
            txtSensorID.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtSensorID.Location = new Point(397, 244);
            txtSensorID.Name = "txtSensorID";
            txtSensorID.Size = new Size(220, 25);
            txtSensorID.TabIndex = 2;
            // 
            // txtEquipID
            // 
            txtEquipID.Anchor = AnchorStyles.None;
            txtEquipID.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtEquipID.Location = new Point(397, 290);
            txtEquipID.Name = "txtEquipID";
            txtEquipID.Size = new Size(220, 25);
            txtEquipID.TabIndex = 2;
            // 
            // txtSensorType
            // 
            txtSensorType.Anchor = AnchorStyles.None;
            txtSensorType.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtSensorType.Location = new Point(397, 336);
            txtSensorType.Name = "txtSensorType";
            txtSensorType.Size = new Size(220, 25);
            txtSensorType.TabIndex = 2;
            // 
            // txtUnit
            // 
            txtUnit.Anchor = AnchorStyles.None;
            txtUnit.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtUnit.Location = new Point(397, 382);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(220, 25);
            txtUnit.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(344, 421);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 45);
            panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Location = new Point(212, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 28);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.None;
            btnDel.Location = new Point(42, 11);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(79, 28);
            btnDel.TabIndex = 3;
            btnDel.Text = "삭제";
            btnDel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Location = new Point(127, 11);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 28);
            btnSave.TabIndex = 3;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(button1, 0, 0);
            tableLayoutPanel3.Controls.Add(button2, 0, 2);
            tableLayoutPanel3.Controls.Add(txtSID, 0, 1);
            tableLayoutPanel3.Controls.Add(button3, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(124, 231);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(19, 125);
            button2.Name = "button2";
            button2.Size = new Size(86, 34);
            button2.TabIndex = 3;
            button2.Text = "조회";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtSID
            // 
            txtSID.Anchor = AnchorStyles.None;
            txtSID.Location = new Point(21, 74);
            txtSID.Name = "txtSID";
            txtSID.Size = new Size(81, 23);
            txtSID.TabIndex = 4;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(19, 184);
            button3.Name = "button3";
            button3.Size = new Size(86, 34);
            button3.TabIndex = 3;
            button3.Text = "센서데이터";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // frmJang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 475);
            Controls.Add(tableLayoutPanel1);
            Name = "frmJang";
            Text = "frmJang";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdList).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView grdList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSensorID;
        private TextBox txtEquipID;
        private TextBox txtSensorType;
        private TextBox txtUnit;
        private Button btnSave;
        private Panel panel1;
        private Button btnCancel;
        private Button btnDel;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button2;
        private TextBox txtSID;
        private Button button3;
    }
}