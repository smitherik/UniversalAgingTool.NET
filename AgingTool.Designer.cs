namespace universalAgingTool
{
    partial class AgingTool
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
            this.TbxFilePath = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnGetSheets = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnView = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.LblAnchorDate = new System.Windows.Forms.Label();
            this.DtpAnchorDate = new System.Windows.Forms.DateTimePicker();
            this.LblFilePath = new System.Windows.Forms.Label();
            this.LbxSheetNames = new System.Windows.Forms.ListBox();
            this.LblSheetNames = new System.Windows.Forms.Label();
            this.BtnGetHeaders = new System.Windows.Forms.Button();
            this.BtnRunAging = new System.Windows.Forms.Button();
            this.LbxDataToAge = new System.Windows.Forms.ListBox();
            this.LbxDatesToAgeBy = new System.Windows.Forms.ListBox();
            this.LblAgeByDate = new System.Windows.Forms.Label();
            this.LblDataToAge = new System.Windows.Forms.Label();
            this.LblHeaders = new System.Windows.Forms.Label();
            this.GrpSheetAndHeader = new System.Windows.Forms.GroupBox();
            this.RbtHeadNo = new System.Windows.Forms.RadioButton();
            this.RbtHeadYes = new System.Windows.Forms.RadioButton();
            this.GrpStart = new System.Windows.Forms.GroupBox();
            this.GrpColumnAndAging = new System.Windows.Forms.GroupBox();
            this.LblProcessing = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reAgeCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitApplictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpSheetAndHeader.SuspendLayout();
            this.GrpStart.SuspendLayout();
            this.GrpColumnAndAging.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbxFilePath
            // 
            this.TbxFilePath.Location = new System.Drawing.Point(90, 81);
            this.TbxFilePath.Name = "TbxFilePath";
            this.TbxFilePath.Size = new System.Drawing.Size(286, 20);
            this.TbxFilePath.TabIndex = 1;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(9, 79);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnGetSheets
            // 
            this.BtnGetSheets.Location = new System.Drawing.Point(382, 79);
            this.BtnGetSheets.Name = "BtnGetSheets";
            this.BtnGetSheets.Size = new System.Drawing.Size(75, 23);
            this.BtnGetSheets.TabIndex = 4;
            this.BtnGetSheets.Text = "Get Sheets";
            this.BtnGetSheets.UseVisualStyleBackColor = true;
            this.BtnGetSheets.Click += new System.EventHandler(this.BtnGetSheets_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(382, 85);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 42);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save Results";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnView
            // 
            this.BtnView.Location = new System.Drawing.Point(382, 32);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(75, 42);
            this.BtnView.TabIndex = 7;
            this.BtnView.Text = "View Results";
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // LblAnchorDate
            // 
            this.LblAnchorDate.AutoSize = true;
            this.LblAnchorDate.Location = new System.Drawing.Point(8, 16);
            this.LblAnchorDate.Name = "LblAnchorDate";
            this.LblAnchorDate.Size = new System.Drawing.Size(421, 13);
            this.LblAnchorDate.TabIndex = 8;
            this.LblAnchorDate.Text = "Select a date that you would like to use as the base date used within the aging p" +
    "rocess.";
            // 
            // DtpAnchorDate
            // 
            this.DtpAnchorDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAnchorDate.Location = new System.Drawing.Point(11, 32);
            this.DtpAnchorDate.Name = "DtpAnchorDate";
            this.DtpAnchorDate.Size = new System.Drawing.Size(116, 20);
            this.DtpAnchorDate.TabIndex = 9;
            this.DtpAnchorDate.Value = new System.DateTime(2020, 1, 16, 0, 0, 0, 0);
            // 
            // LblFilePath
            // 
            this.LblFilePath.AutoSize = true;
            this.LblFilePath.Location = new System.Drawing.Point(6, 63);
            this.LblFilePath.Name = "LblFilePath";
            this.LblFilePath.Size = new System.Drawing.Size(289, 13);
            this.LblFilePath.TabIndex = 10;
            this.LblFilePath.Text = "Use the search button by to select the Excel file to be aged.\r\n";
            // 
            // LbxSheetNames
            // 
            this.LbxSheetNames.FormattingEnabled = true;
            this.LbxSheetNames.Location = new System.Drawing.Point(125, 15);
            this.LbxSheetNames.Name = "LbxSheetNames";
            this.LbxSheetNames.Size = new System.Drawing.Size(120, 56);
            this.LbxSheetNames.TabIndex = 11;
            // 
            // LblSheetNames
            // 
            this.LblSheetNames.Location = new System.Drawing.Point(6, 15);
            this.LblSheetNames.Name = "LblSheetNames";
            this.LblSheetNames.Size = new System.Drawing.Size(113, 56);
            this.LblSheetNames.TabIndex = 12;
            this.LblSheetNames.Text = "Select the worksheet name that contains the data to be aged.";
            // 
            // BtnGetHeaders
            // 
            this.BtnGetHeaders.Location = new System.Drawing.Point(382, 15);
            this.BtnGetHeaders.Name = "BtnGetHeaders";
            this.BtnGetHeaders.Size = new System.Drawing.Size(75, 56);
            this.BtnGetHeaders.TabIndex = 14;
            this.BtnGetHeaders.Text = "Get Headers or Columns";
            this.BtnGetHeaders.UseVisualStyleBackColor = true;
            this.BtnGetHeaders.Click += new System.EventHandler(this.BtnGetHeaders_Click);
            // 
            // BtnRunAging
            // 
            this.BtnRunAging.Location = new System.Drawing.Point(287, 32);
            this.BtnRunAging.Name = "BtnRunAging";
            this.BtnRunAging.Size = new System.Drawing.Size(75, 95);
            this.BtnRunAging.TabIndex = 15;
            this.BtnRunAging.Text = "Run Aging";
            this.BtnRunAging.UseVisualStyleBackColor = true;
            this.BtnRunAging.Click += new System.EventHandler(this.BtnRunAging_Click);
            // 
            // LbxDataToAge
            // 
            this.LbxDataToAge.FormattingEnabled = true;
            this.LbxDataToAge.Location = new System.Drawing.Point(146, 32);
            this.LbxDataToAge.Name = "LbxDataToAge";
            this.LbxDataToAge.Size = new System.Drawing.Size(120, 95);
            this.LbxDataToAge.TabIndex = 19;
            // 
            // LbxDatesToAgeBy
            // 
            this.LbxDatesToAgeBy.FormattingEnabled = true;
            this.LbxDatesToAgeBy.Location = new System.Drawing.Point(9, 32);
            this.LbxDatesToAgeBy.Name = "LbxDatesToAgeBy";
            this.LbxDatesToAgeBy.Size = new System.Drawing.Size(120, 95);
            this.LbxDatesToAgeBy.TabIndex = 20;
            // 
            // LblAgeByDate
            // 
            this.LblAgeByDate.AutoSize = true;
            this.LblAgeByDate.Location = new System.Drawing.Point(8, 16);
            this.LblAgeByDate.Name = "LblAgeByDate";
            this.LblAgeByDate.Size = new System.Drawing.Size(121, 13);
            this.LblAgeByDate.TabIndex = 21;
            this.LblAgeByDate.Text = "Select column to age by";
            // 
            // LblDataToAge
            // 
            this.LblDataToAge.AutoSize = true;
            this.LblDataToAge.Location = new System.Drawing.Point(143, 16);
            this.LblDataToAge.Name = "LblDataToAge";
            this.LblDataToAge.Size = new System.Drawing.Size(128, 13);
            this.LblDataToAge.TabIndex = 22;
            this.LblDataToAge.Text = "Select column to be aged";
            // 
            // LblHeaders
            // 
            this.LblHeaders.Location = new System.Drawing.Point(264, 15);
            this.LblHeaders.Name = "LblHeaders";
            this.LblHeaders.Size = new System.Drawing.Size(91, 33);
            this.LblHeaders.TabIndex = 23;
            this.LblHeaders.Text = "Does the dataset contain headers?";
            // 
            // GrpSheetAndHeader
            // 
            this.GrpSheetAndHeader.Controls.Add(this.RbtHeadNo);
            this.GrpSheetAndHeader.Controls.Add(this.LblHeaders);
            this.GrpSheetAndHeader.Controls.Add(this.RbtHeadYes);
            this.GrpSheetAndHeader.Controls.Add(this.BtnGetHeaders);
            this.GrpSheetAndHeader.Controls.Add(this.LblSheetNames);
            this.GrpSheetAndHeader.Controls.Add(this.LbxSheetNames);
            this.GrpSheetAndHeader.Location = new System.Drawing.Point(4, 151);
            this.GrpSheetAndHeader.Name = "GrpSheetAndHeader";
            this.GrpSheetAndHeader.Size = new System.Drawing.Size(465, 80);
            this.GrpSheetAndHeader.TabIndex = 24;
            this.GrpSheetAndHeader.TabStop = false;
            // 
            // RbtHeadNo
            // 
            this.RbtHeadNo.Location = new System.Drawing.Point(315, 46);
            this.RbtHeadNo.Name = "RbtHeadNo";
            this.RbtHeadNo.Size = new System.Drawing.Size(44, 19);
            this.RbtHeadNo.TabIndex = 29;
            this.RbtHeadNo.Text = "No";
            this.RbtHeadNo.UseVisualStyleBackColor = true;
            this.RbtHeadNo.CheckedChanged += new System.EventHandler(this.RbtHeadNo_CheckedChanged);
            // 
            // RbtHeadYes
            // 
            this.RbtHeadYes.Location = new System.Drawing.Point(265, 46);
            this.RbtHeadYes.Name = "RbtHeadYes";
            this.RbtHeadYes.Size = new System.Drawing.Size(44, 19);
            this.RbtHeadYes.TabIndex = 28;
            this.RbtHeadYes.TabStop = true;
            this.RbtHeadYes.Text = "Yes";
            this.RbtHeadYes.UseVisualStyleBackColor = true;
            this.RbtHeadYes.CheckedChanged += new System.EventHandler(this.RbtHeadYes_CheckedChanged);
            // 
            // GrpStart
            // 
            this.GrpStart.Controls.Add(this.LblFilePath);
            this.GrpStart.Controls.Add(this.DtpAnchorDate);
            this.GrpStart.Controls.Add(this.LblAnchorDate);
            this.GrpStart.Controls.Add(this.BtnGetSheets);
            this.GrpStart.Controls.Add(this.BtnSearch);
            this.GrpStart.Controls.Add(this.TbxFilePath);
            this.GrpStart.Location = new System.Drawing.Point(4, 30);
            this.GrpStart.Name = "GrpStart";
            this.GrpStart.Size = new System.Drawing.Size(465, 115);
            this.GrpStart.TabIndex = 25;
            this.GrpStart.TabStop = false;
            // 
            // GrpColumnAndAging
            // 
            this.GrpColumnAndAging.Controls.Add(this.LblProcessing);
            this.GrpColumnAndAging.Controls.Add(this.LblDataToAge);
            this.GrpColumnAndAging.Controls.Add(this.LblAgeByDate);
            this.GrpColumnAndAging.Controls.Add(this.LbxDatesToAgeBy);
            this.GrpColumnAndAging.Controls.Add(this.BtnSave);
            this.GrpColumnAndAging.Controls.Add(this.LbxDataToAge);
            this.GrpColumnAndAging.Controls.Add(this.BtnRunAging);
            this.GrpColumnAndAging.Controls.Add(this.BtnView);
            this.GrpColumnAndAging.Location = new System.Drawing.Point(4, 237);
            this.GrpColumnAndAging.Name = "GrpColumnAndAging";
            this.GrpColumnAndAging.Size = new System.Drawing.Size(465, 134);
            this.GrpColumnAndAging.TabIndex = 26;
            this.GrpColumnAndAging.TabStop = false;
            // 
            // LblProcessing
            // 
            this.LblProcessing.AutoSize = true;
            this.LblProcessing.Location = new System.Drawing.Point(296, 73);
            this.LblProcessing.Name = "LblProcessing";
            this.LblProcessing.Size = new System.Drawing.Size(59, 13);
            this.LblProcessing.TabIndex = 28;
            this.LblProcessing.Text = "Processing";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(477, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reAgeCurrentFileToolStripMenuItem,
            this.resetApplicationToolStripMenuItem,
            this.exitApplictionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.fileToolStripMenuItem.Text = "Application";
            // 
            // reAgeCurrentFileToolStripMenuItem
            // 
            this.reAgeCurrentFileToolStripMenuItem.Name = "reAgeCurrentFileToolStripMenuItem";
            this.reAgeCurrentFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reAgeCurrentFileToolStripMenuItem.Text = "ReAge Current File";
            this.reAgeCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.ReAgeCurrentFileToolStripMenuItem_Click);
            // 
            // resetApplicationToolStripMenuItem
            // 
            this.resetApplicationToolStripMenuItem.Name = "resetApplicationToolStripMenuItem";
            this.resetApplicationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetApplicationToolStripMenuItem.Text = "Reset Application";
            this.resetApplicationToolStripMenuItem.Click += new System.EventHandler(this.ResetApplicationToolStripMenuItem_Click);
            // 
            // exitApplictionToolStripMenuItem
            // 
            this.exitApplictionToolStripMenuItem.Name = "exitApplictionToolStripMenuItem";
            this.exitApplictionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitApplictionToolStripMenuItem.Text = "Exit Appliction";
            this.exitApplictionToolStripMenuItem.Click += new System.EventHandler(this.ExitApplictionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // AgingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 378);
            this.Controls.Add(this.GrpColumnAndAging);
            this.Controls.Add(this.GrpStart);
            this.Controls.Add(this.GrpSheetAndHeader);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AgingTool";
            this.Text = "PCNPS Aging Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgingTool_FormClosing);
            this.GrpSheetAndHeader.ResumeLayout(false);
            this.GrpStart.ResumeLayout(false);
            this.GrpStart.PerformLayout();
            this.GrpColumnAndAging.ResumeLayout(false);
            this.GrpColumnAndAging.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TbxFilePath;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnGetSheets;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label LblAnchorDate;
        private System.Windows.Forms.DateTimePicker DtpAnchorDate;
        private System.Windows.Forms.Label LblFilePath;
        private System.Windows.Forms.ListBox LbxSheetNames;
        private System.Windows.Forms.Label LblSheetNames;
        private System.Windows.Forms.Button BtnGetHeaders;
        private System.Windows.Forms.Button BtnRunAging;
        private System.Windows.Forms.ListBox LbxDataToAge;
        private System.Windows.Forms.ListBox LbxDatesToAgeBy;
        private System.Windows.Forms.Label LblAgeByDate;
        private System.Windows.Forms.Label LblDataToAge;
        private System.Windows.Forms.Label LblHeaders;
        private System.Windows.Forms.GroupBox GrpSheetAndHeader;
        private System.Windows.Forms.GroupBox GrpStart;
        private System.Windows.Forms.GroupBox GrpColumnAndAging;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitApplictionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.RadioButton RbtHeadNo;
        private System.Windows.Forms.RadioButton RbtHeadYes;
        private System.Windows.Forms.Label LblProcessing;
        private System.Windows.Forms.ToolStripMenuItem reAgeCurrentFileToolStripMenuItem;
    }
}

