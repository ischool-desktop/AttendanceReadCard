namespace AttendanceReadCard
{
    partial class SetupForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClassMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chClassName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.chCardName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgvPeriodMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chCardPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPeriod = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cboLateMap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboEmptyMap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAutoClass = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoPeriod = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboOverride = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassMap
            // 
            this.dgvClassMap.AllowUserToAddRows = false;
            this.dgvClassMap.AllowUserToDeleteRows = false;
            this.dgvClassMap.AllowUserToResizeRows = false;
            this.dgvClassMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvClassMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chClassName,
            this.chCardName});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClassMap.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvClassMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvClassMap.HighlightSelectedColumnHeaders = false;
            this.dgvClassMap.Location = new System.Drawing.Point(12, 38);
            this.dgvClassMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClassMap.Name = "dgvClassMap";
            this.dgvClassMap.RowTemplate.Height = 24;
            this.dgvClassMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvClassMap.Size = new System.Drawing.Size(253, 316);
            this.dgvClassMap.TabIndex = 1;
            this.dgvClassMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassMap_CellClick);
            this.dgvClassMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvClassMap_KeyUp);
            // 
            // chClassName
            // 
            this.chClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chClassName.DefaultCellStyle = dataGridViewCellStyle9;
            this.chClassName.DisplayMember = "Text";
            this.chClassName.DropDownHeight = 106;
            this.chClassName.DropDownWidth = 121;
            this.chClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chClassName.HeaderText = "班級名稱";
            this.chClassName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chClassName.IntegralHeight = false;
            this.chClassName.ItemHeight = 17;
            this.chClassName.Name = "chClassName";
            this.chClassName.ReadOnly = true;
            this.chClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chClassName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // chCardName
            // 
            this.chCardName.DropDownHeight = 106;
            this.chCardName.DropDownWidth = 121;
            this.chCardName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chCardName.HeaderText = "讀卡代碼";
            this.chCardName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chCardName.IntegralHeight = false;
            this.chCardName.ItemHeight = 17;
            this.chCardName.Name = "chCardName";
            this.chCardName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chCardName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "班級名稱對照";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(285, 365);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 21);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "缺曠類別對應";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(285, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "節次對照";
            // 
            // dgvPeriodMap
            // 
            this.dgvPeriodMap.AllowUserToAddRows = false;
            this.dgvPeriodMap.AllowUserToDeleteRows = false;
            this.dgvPeriodMap.AllowUserToResizeRows = false;
            this.dgvPeriodMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chCardPeriod,
            this.chPeriod});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeriodMap.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPeriodMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPeriodMap.HighlightSelectedColumnHeaders = false;
            this.dgvPeriodMap.Location = new System.Drawing.Point(285, 38);
            this.dgvPeriodMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPeriodMap.Name = "dgvPeriodMap";
            this.dgvPeriodMap.RowTemplate.Height = 24;
            this.dgvPeriodMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPeriodMap.Size = new System.Drawing.Size(250, 316);
            this.dgvPeriodMap.TabIndex = 8;
            this.dgvPeriodMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodMap_CellClick);
            this.dgvPeriodMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPeriodMap_KeyUp);
            // 
            // chCardPeriod
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chCardPeriod.DefaultCellStyle = dataGridViewCellStyle11;
            this.chCardPeriod.HeaderText = "讀卡節次";
            this.chCardPeriod.Name = "chCardPeriod";
            this.chCardPeriod.ReadOnly = true;
            this.chCardPeriod.Width = 90;
            // 
            // chPeriod
            // 
            this.chPeriod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chPeriod.DropDownHeight = 106;
            this.chPeriod.DropDownWidth = 121;
            this.chPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chPeriod.HeaderText = "節次";
            this.chPeriod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chPeriod.IntegralHeight = false;
            this.chPeriod.ItemHeight = 17;
            this.chPeriod.Name = "chPeriod";
            this.chPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(389, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(473, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(285, 394);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(20, 21);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "遲";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(421, 394);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(20, 21);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "缺";
            // 
            // cboLateMap
            // 
            this.cboLateMap.DisplayMember = "Text";
            this.cboLateMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLateMap.FormattingEnabled = true;
            this.cboLateMap.ItemHeight = 19;
            this.cboLateMap.Location = new System.Drawing.Point(312, 392);
            this.cboLateMap.Name = "cboLateMap";
            this.cboLateMap.Size = new System.Drawing.Size(88, 25);
            this.cboLateMap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLateMap.TabIndex = 4;
            // 
            // cboEmptyMap
            // 
            this.cboEmptyMap.DisplayMember = "Text";
            this.cboEmptyMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEmptyMap.FormattingEnabled = true;
            this.cboEmptyMap.ItemHeight = 19;
            this.cboEmptyMap.Location = new System.Drawing.Point(447, 392);
            this.cboEmptyMap.Name = "cboEmptyMap";
            this.cboEmptyMap.Size = new System.Drawing.Size(88, 25);
            this.cboEmptyMap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboEmptyMap.TabIndex = 6;
            // 
            // btnAutoClass
            // 
            this.btnAutoClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoClass.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoClass.Location = new System.Drawing.Point(105, 11);
            this.btnAutoClass.Name = "btnAutoClass";
            this.btnAutoClass.Size = new System.Drawing.Size(75, 23);
            this.btnAutoClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoClass.TabIndex = 11;
            this.btnAutoClass.Text = "自動產生";
            this.btnAutoClass.Visible = false;
            // 
            // btnAutoPeriod
            // 
            this.btnAutoPeriod.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoPeriod.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoPeriod.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoPeriod.Location = new System.Drawing.Point(353, 11);
            this.btnAutoPeriod.Name = "btnAutoPeriod";
            this.btnAutoPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnAutoPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoPeriod.TabIndex = 12;
            this.btnAutoPeriod.Text = "自動對照";
            this.btnAutoPeriod.Visible = false;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 365);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(208, 21);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "讀卡資料與現有資料衝突處理方式";
            // 
            // cboOverride
            // 
            this.cboOverride.DisplayMember = "Text";
            this.cboOverride.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOverride.FormattingEnabled = true;
            this.cboOverride.ItemHeight = 19;
            this.cboOverride.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cboOverride.Location = new System.Drawing.Point(12, 392);
            this.cboOverride.Name = "cboOverride";
            this.cboOverride.Size = new System.Drawing.Size(113, 25);
            this.cboOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboOverride.TabIndex = 14;
            this.cboOverride.Text = "略過讀卡資料";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "覆蓋現有資料";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "略過讀卡資料";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 469);
            this.Controls.Add(this.cboOverride);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.btnAutoPeriod);
            this.Controls.Add(this.btnAutoClass);
            this.Controls.Add(this.cboEmptyMap);
            this.Controls.Add(this.cboLateMap);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPeriodMap);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgvClassMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SetupForm";
            this.Text = "學生出缺席讀卡設定";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvClassMap;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPeriodMap;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLateMap;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboEmptyMap;
        private DevComponents.DotNetBar.ButtonX btnAutoClass;
        private DevComponents.DotNetBar.ButtonX btnAutoPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCardPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chCardName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboOverride;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}