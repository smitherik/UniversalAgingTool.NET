using System;
using System.Windows;
using System.Windows.Forms;


namespace universalAgingTool
{
    public partial class AgingTool : Form
    {
        private ExcelDataFile ExcelThread { get; set; }

        private AgedDataStore AgedData { get; set; }

        public AgingTool()
        {
            InitializeComponent();
            ExcelThread = new ExcelDataFile();
            AgedData = new AgedDataStore();
            ConfigureApplication();
        }

        private void ConfigureApplication()
        {
            TbxFilePath.ResetText();
            ExcelThread.Reset();
            saveFileDialog.Reset();
            openFileDialog.Reset();
            LbxSheetNames.Items.Clear();

            DtpAnchorDate.Value       = DateTime.Today;
            RbtHeadNo.Checked         = false;
            RbtHeadYes.Checked        = false;
            GrpSheetAndHeader.Visible = false;
            GrpColumnAndAging.Visible = false;
            BtnGetHeaders.Visible     = false;            

            PrepForAging();
            ZeroAgingAccum();
        }

        public void PrepForAging()
        {
            LbxDataToAge.Items.Clear();
            LbxDatesToAgeBy.Items.Clear();
            BtnSave.Visible       = false;
            BtnView.Visible       = false;
            LblProcessing.Visible = false;
            LblProcessing.Text    = "Processing";
            BtnRunAging.Visible   = true;
        }

        public void ZeroAgingAccum()
        {
            AgedData.Day0To30    = default;
            AgedData.Day31To60   = default;
            AgedData.Day61To90   = default;
            AgedData.Day91To120  = default;
            AgedData.Day121To150 = default;
            AgedData.Day151To180 = default;
            AgedData.Day181To270 = default;
            AgedData.Day271To360 = default;
            AgedData.Day361Plus  = default;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TbxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void BtnGetSheets_Click(object sender, EventArgs e)
        {
            if (ValidationLogic.InvalidFile(TbxFilePath))
            {
                ErrorActions.InvalidFile();
            }
            else
            {
                try
                {
                    string file = TbxFilePath.Text.ToString();
                    ExcelThread.OpenWorkbook(file);
                    ExcelThread.GetSheets();
                    LbxSheetNames.Items.Clear();
                    for (int i = 1; i <= ExcelThread.Worksheets.Count; i++)
                    {
                        Microsoft.Office.Interop.Excel.Worksheet sheet = ExcelThread.Worksheets[i];
                        LbxSheetNames.Items.Add(sheet.Name.ToString());
                    }
                    GrpSheetAndHeader.Visible = true;
                }
                catch
                {
                    ErrorActions.FailOpenFile();
                }
            }
        }

        private void BtnGetHeaders_Click(object sender, EventArgs e)
        {
            BuildHeaders();
        }

        private void BuildHeaders()
        {
            if (ValidationLogic.NoItemSelected(LbxSheetNames))
            {
                ErrorActions.NoSheetSelected();
            }
            else
            {
                string sheetWithData = LbxSheetNames.SelectedItem.ToString();
                ExcelThread.Worksheet = ExcelThread.Worksheets[sheetWithData];
                if (ValidationLogic.NoColumnsFound(ExcelThread.Worksheet))
                {
                    ErrorActions.NoColumnsFound();
                }
                else
                {
                    ExcelThread.DataSet = ExcelThread.Worksheet.UsedRange;
                    int colCount = ExcelThread.DataSet.Columns.Count;
                    LbxDataToAge.Items.Clear();
                    LbxDatesToAgeBy.Items.Clear();
                    if (RbtHeadYes.Checked)
                    {
                        for (int i = 1; i <= colCount; i++)
                        {
                            Microsoft.Office.Interop.Excel.Range cellValue = ExcelThread.DataSet.Cells[1, i];
                            LbxDatesToAgeBy.Items.Add(cellValue.Value.ToString());
                            LbxDataToAge.Items.Add(cellValue.Value.ToString());
                        }
                        GrpColumnAndAging.Visible = true;
                    }
                    else if (RbtHeadNo.Checked)
                    {
                        for (int i = 1; i <= colCount; i++)
                        {
                            string columnNumber = "Column " + i.ToString();
                            LbxDatesToAgeBy.Items.Add(columnNumber);
                            LbxDataToAge.Items.Add(columnNumber);
                        }
                        GrpColumnAndAging.Visible = true;
                    }
                    else
                    {
                        ErrorActions.HeaderNotAnswered();
                    }
                }
            }
        }

        private void BtnRunAging_Click(object sender, EventArgs e)
        {
            if (ValidationLogic.DateInvalid(DtpAnchorDate.Value))
            {
                ErrorActions.DateInFuture();
            }
            else if (ValidationLogic.ColumnsNotSelected(LbxDataToAge, LbxDatesToAgeBy))
            {
                ErrorActions.ColumnsNotSelected();
            }
            else
            {
                BtnRunAging.Visible   = false;
                LblProcessing.Visible = true;
                ZeroAgingAccum();
                int dateColumn  = LbxDatesToAgeBy.SelectedIndex + 1;
                int valueColumn = LbxDataToAge.SelectedIndex + 1;
                for (int i = 2; i <= ExcelThread.DataSet.Rows.Count; i++)
                {
                    var rawDate = ExcelThread.DataSet.Cells[i, dateColumn].Value2;
                    var rawVal = ExcelThread.DataSet.Cells[i, valueColumn].Value2;
                    if (rawDate is null || rawVal is null)
                    {
                        continue;
                    }
                    Type dateType = rawDate.GetType();
                    Type valType = rawVal.GetType();
                    int bucket = -1;
                    float value = (float)-1.0;

                    if (dateType.Name != "Double")
                    {
                        ErrorActions.InvalidDataType();
                    }
                    else
                    {
                        int daysPast = (DtpAnchorDate.Value - DateTime.FromOADate(rawDate)).Days;
                        bucket = daysPast / (int)30;
                    }

                    if (valType.Name == "Double")
                    {
                        value = (float)rawVal;
                    }
                    else if (valType.Name == "String")
                    {
                        try
                        {
                            value = float.Parse(rawVal);
                        }
                        catch
                        {
                            ErrorActions.InvalidDataType();
                        }
                    }
                    else
                    {
                        ErrorActions.InvalidDataType();
                    }
                    if (bucket == -1 || value == (float)-1.0)
                    {
                        ErrorActions.InvalidValue();
                    }
                    else
                    {
                        AgedData.AddAgedData(bucket, value);
                    }
                }
                LblProcessing.Text = "Complete";
                BtnView.Visible = true;
                BtnSave.Visible = true;
            }
        }

        private void ResetApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigureApplication();
            ExcelThread.Reset();
        }

        private void ExitApplictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RbtHeadNo_CheckedChanged(object sender, EventArgs e)
        {
            BtnGetHeaders.Visible = true;
        }

        private void RbtHeadYes_CheckedChanged(object sender, EventArgs e)
        {
            BtnGetHeaders.Visible = true;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            var agedData = new ViewAgedData(TbxFilePath.Text.ToString(), 
                                            DtpAnchorDate.Value, 
                                            LbxDatesToAgeBy.SelectedItem.ToString(),
                                            LbxDataToAge.SelectedItem.ToString(),
                                            AgedData);
            agedData.Show();
            
        }

        private void AgingTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelThread.Shutdown();
        }

        private void ReAgeCurrentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelThread.Reset();
            string file = TbxFilePath.Text.ToString();
            ExcelThread.OpenWorkbook(file);
            ExcelThread.GetSheets();
            if (ValidationLogic.NoItemSelected(LbxSheetNames))
            {
                ErrorActions.NoSheetSelected();
            }
            else
            {
                string sheetWithData = LbxSheetNames.SelectedItem.ToString();
                ExcelThread.Worksheet = ExcelThread.Worksheets[sheetWithData];
                if (ValidationLogic.NoColumnsFound(ExcelThread.Worksheet))
                {
                    ErrorActions.NoColumnsFound();
                }
                else
                {
                    BuildHeaders();
                    PrepForAging();
                }
            }
                    
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.ShowDialog();
            //MessageBox.Show(saveFileDialog.FileName);
            ExcelThread.Reset();
            ExcelThread.Workbook = ExcelThread.App.Workbooks.Add();
            ExcelThread.Worksheet = ExcelThread.Workbook.Worksheets[1];
            //ExcelThread.Worksheet = ExcelThread.Worksheets[0];
            ExcelThread.Worksheet.Cells[1, 1]              = "Aging results for file " + 
                                                             TbxFilePath.Text.ToString();
            ExcelThread.Worksheet.Cells[2, 1]              = "being performed on " + 
                                                             LbxDatesToAgeBy.SelectedItem.ToString() + 
                                                             " from " + 
                                                             DtpAnchorDate.Value.ToString("MM/dd/yyyy");
            ExcelThread.Worksheet.Cells[4, 1]              = "Days Included";
            ExcelThread.Worksheet.Cells[4, 2]              = "Summary of " + 
                                                             LbxDataToAge.SelectedItem.ToString();
            ExcelThread.Worksheet.Cells[5, 1]              = "'000 - 030";
            ExcelThread.Worksheet.Cells[6, 1]              = "'031 - 060";
            ExcelThread.Worksheet.Cells[7, 1]              = "'061 - 090";
            ExcelThread.Worksheet.Cells[8, 1]              = "'091 - 120";
            ExcelThread.Worksheet.Cells[9, 1]              = "'121 - 150";
            ExcelThread.Worksheet.Cells[10, 1]             = "'151 - 180";
            ExcelThread.Worksheet.Cells[11, 1]             = "'181 - 270";
            ExcelThread.Worksheet.Cells[12, 1]             = "'271 - 360";
            ExcelThread.Worksheet.Cells[13, 1]             = "'361 - +++";
            ExcelThread.Worksheet.Cells[5, 2]              = AgedData.Day0To30;
            ExcelThread.Worksheet.Cells[6, 2]              = AgedData.Day31To60;
            ExcelThread.Worksheet.Cells[7, 2]              = AgedData.Day61To90;
            ExcelThread.Worksheet.Cells[8, 2]              = AgedData.Day91To120;
            ExcelThread.Worksheet.Cells[9, 2]              = AgedData.Day121To150;
            ExcelThread.Worksheet.Cells[10, 2]             = AgedData.Day151To180;
            ExcelThread.Worksheet.Cells[11, 2]             = AgedData.Day181To270;
            ExcelThread.Worksheet.Cells[12, 2]             = AgedData.Day271To360;
            ExcelThread.Worksheet.Cells[13, 2]             = AgedData.Day361Plus;
            ExcelThread.Worksheet.Range["A:A"].ColumnWidth = 13;
            ExcelThread.Worksheet.Range["B:B"].ColumnWidth = 16;
            ExcelThread.Worksheet.Range["A4:A13"].HorizontalAlignment = HorizontalAlignment.Center;
            ExcelThread.Worksheet.Range["B5:B13"].NumberFormat = "_($* #,##0.00_)";
            ExcelThread.Workbook.SaveAs(saveFileDialog.FileName);
        }
    }
}
