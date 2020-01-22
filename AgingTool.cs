/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    This application takes an excel file (xlsx format) as in input
               and walks the user though selecting a sheet within the workbook
               along with the individual columns to use for calculating days
               past (the aging bucket) and the sum of all values (float) that
               coorelate to those buckets. Finally the user get the option to 
               review the results while in memory or write them to disk. 
-------------------------------------------------------------------------------
    Modification History
  
    01/21/2020  Erik W. Smith
    [1:eof]
        Initial development.
-----------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;


namespace universalAgingTool
{
    public partial class AgingTool : Form
    {
        private ExcelDataFile ExcelThread { get; set; }

        private AgedDataStore AgedData    { get; set; }

        public AgingTool()
        {
            InitializeComponent();
            ExcelThread = new ExcelDataFile();
            AgedData    = new AgedDataStore();
            ConfigureApplication();
        }

        private void ConfigureApplication()
        {
            // ensuring all properties are clear except for the 'App' Excel application pointer
            ExcelThread.Reset();
            
            // ensure form components are in a state ready to accept used input
            DtpAnchorDate.Value       = DateTime.Today;
            RbtHeadNo.Checked         = false;
            RbtHeadYes.Checked        = false;
            GrpSheetAndHeader.Visible = false;
            GrpColumnAndAging.Visible = false;
            BtnGetHeaders.Visible     = false;            
            TbxFilePath.ResetText();
            saveFileDialog.Reset();
            openFileDialog.Reset();
            LbxSheetNames.Items.Clear();
            PrepForAging(); /* broke out some of the application configuration to 
                             * support 'reseting' the application in order to allow 
                             * the user to age the same excel data set based on 
                             * differing input conditions */
            
            // ensure our results accumilator is ready for use.
            AgedData.Zero();
        }

        public void PrepForAging()
        {
            // reset the application state prior to the user pressing 'get headers or columns'
            LbxDataToAge.Items.Clear();
            LbxDatesToAgeBy.Items.Clear();
            BtnSave.Visible       = false;
            BtnView.Visible       = false;
            LblProcessing.Visible = false;
            LblProcessing.Text    = "Processing";
            BtnRunAging.Visible   = true;
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
                    /* using form inputs open the file and loop through all sheets within
                     * the workbook, adding the name of each sheet encountered into a list
                     * box that the user can select from. */
                    string file = TbxFilePath.Text.ToString();
                    ExcelThread.OpenWorkbook(file);
                    ExcelThread.GetSheets();
                    LbxSheetNames.Items.Clear();
                    for (int i = 1; i <= ExcelThread.Worksheets.Count; i++)
                    {
                        Microsoft.Office.Interop.Excel.Worksheet sheet = ExcelThread.Worksheets[i];
                        LbxSheetNames.Items.Add(sheet.Name.ToString());
                    }
                    // make the next stage of the process/application visible. 
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
                // set the specific sheet by using the selected sheet name from the list box control.
                string sheetWithData  = LbxSheetNames.SelectedItem.ToString();
                ExcelThread.Worksheet = ExcelThread.Worksheets[sheetWithData];
                if (ValidationLogic.NoColumnsFound(ExcelThread.Worksheet))
                {
                    ErrorActions.NoColumnsFound();
                }
                else
                {
                    // Determine the number of columns within the sheet that are actually holding values
                    ExcelThread.DataSet = ExcelThread.Worksheet.UsedRange;
                    int colCount        = ExcelThread.DataSet.Columns.Count;
                    
                    /* the following two lines are required to ensure if the user changes the value
                     * of their answer for if headers are included and re-clicks the button the 
                     * list box control does not 'grow' with the new selection. In addition columns
                     * to be used in the Aging process are selected by index, therefore the order of
                     * the list box controls must not be sorted. ORDER MATTERS!!!! */
                    LbxDataToAge.Items.Clear();
                    LbxDatesToAgeBy.Items.Clear();
                    
                    /* if headers exist loop through all columns and add the value of the first
                     * row into two list box controls, what to age and what to age by. */
                    if (RbtHeadYes.Checked)
                    {
                        for (int i = 1; i <= colCount; i++)
                        {
                            Microsoft.Office.Interop.Excel.Range cellValue = ExcelThread.DataSet.Cells[1, i];
                            LbxDatesToAgeBy.Items.Add(cellValue.Value.ToString());
                            LbxDataToAge.Items.Add(cellValue.Value.ToString());
                        }
                        // make the next stage of the process/application visible. 
                        GrpColumnAndAging.Visible = true;
                    }
                    /* if no headers exist add 'Column X' where X represents the column number, 
                     * into two list box controls, what to age and what to age by. */
                    else if (RbtHeadNo.Checked)
                    {
                        for (int i = 1; i <= colCount; i++)
                        {
                            string columnNumber = "Column " + i.ToString();
                            LbxDatesToAgeBy.Items.Add(columnNumber);
                            LbxDataToAge.Items.Add(columnNumber);
                        }
                        // make the next stage of the process/application visible. 
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
                // simple visibility changes are how the processing status is communicated.
                BtnRunAging.Visible   = false;
                LblProcessing.Visible = true;
                // ensure our accumilator is ready to receive data.
                AgedData.Zero();
                int dateColumn  = LbxDatesToAgeBy.SelectedIndex + 1; // Excel arrays are not 0 based
                int valueColumn = LbxDataToAge.SelectedIndex    + 1; // Excel arrays are not 0 based

                // since our data included a header we skip over the first row (i=2).
                for (int i = 2; i <= ExcelThread.DataSet.Rows.Count; i++)
                {
                    // value2 property doesn’t use the Currency and Date data types returns as Double
                    var rawDate = ExcelThread.DataSet.Cells[i, dateColumn].Value2; 
                    var rawVal  = ExcelThread.DataSet.Cells[i, valueColumn].Value2;
                    
                    /* since we are not validating the existance of data within each cell in our dataset
                     * we need to check that we sucessfully returned non-nulls. If either the value 
                     * within the 'to age' or the 'to age by' column for a given row are empty the 
                     * entire row will be skipped. This application is not intended to clean data only
                     * process an existing proper dataset. */
                    if (rawDate is null || rawVal is null)
                    {
                        continue;
                    }
                    
                    // getting the types of the data returned and also setting flags used in type checking. 
                    Type  dateType = rawDate.GetType();
                    Type  valType  = rawVal.GetType();
                    int   bucket   = -1;
                    float value    = (float)-1.0;

                    /* by using the Value2 property we ensure that dates will be read in at Doubles. Given
                     * the stagering diversity in the way date strings are represented the decision was 
                     * made to reject any dates not formated as a date, datetime, or number within excel. */ 
                    if (dateType.Name != "Double")
                    {
                        ErrorActions.InvalidDataType();
                    }
                    else
                    {
                        int daysPast = (DtpAnchorDate.Value - DateTime.FromOADate(rawDate)).Days;
                        bucket = daysPast / (int)30; // explicitly casting denominator at int because I am paranoid.
                    }

                    /* if the 'to age' value read in was a double (because of using Value2) we cast it 
                     * to a float and we parse any string received into a float as well. */
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

                    // finally we validate our type check flags and update our accumlator
                    if (bucket == -1 || value == (float)-1.0)
                    {
                        ErrorActions.InvalidValue();
                    }
                    else
                    {
                        AgedData.AddAgedData(bucket, value);
                    }
                }
                // simple visibility and text changes are how the processing status is communicated.
                LblProcessing.Text = "Complete"; // text was changed to eliminate a control from the form.
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

        // only show the button to get headers if the user has indicated if there are headers or not. 
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
            var results = new ResultsDataStruct(TbxFilePath.Text.ToString(),
                                                DtpAnchorDate.Value,
                                                LbxDatesToAgeBy.SelectedItem.ToString(),
                                                LbxDataToAge.SelectedItem.ToString(),
                                                AgedData);

            var agedData = new ViewAgedData(results);
            agedData.Show();
            
        }

        /* Since this is only a one form application the decision was made to clean up
         * the reserved excel process and thread no mater the method the form was 
         * closed. The intent was to attempt to catch and not leave orphaned process
         * threads. */
        private void AgingTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelThread.Shutdown();
        }

        /* this method is designed to allow the user to perform a soft reset and reset
         * the application to the state direcly after pressin the 'get headers or 
         * columns' button. The intent is to allow mutiple agings of the same data 
         * making use of different headers on subsquent agings. */
        private void ReAgeCurrentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // subset of get sheets button event. 
            ExcelThread.Reset();
            string file = TbxFilePath.Text.ToString();
            ExcelThread.OpenWorkbook(file);
            ExcelThread.GetSheets();

            // subset of the get headers button event. 
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

        // the saving process writes a formated excel file to a location of the users choice. 
        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.ShowDialog();
            // clear thread of our dataset connection and add a connection to our new in memory file.
            ExcelThread.Reset();
            ExcelThread.Workbook = ExcelThread.App.Workbooks.Add();
            ExcelThread.Worksheet = ExcelThread.Workbook.Worksheets[1];

            // Write the title and header information.
            ExcelThread.Worksheet.Cells[1, 1]              = "Aging results for file " + 
                                                             TbxFilePath.Text.ToString();
            ExcelThread.Worksheet.Cells[2, 1]              = "being performed on " + 
                                                             LbxDatesToAgeBy.SelectedItem.ToString() + 
                                                             " from " + 
                                                             DtpAnchorDate.Value.ToString("MM/dd/yyyy");
            ExcelThread.Worksheet.Cells[4, 1]              = "Days Included";
            ExcelThread.Worksheet.Cells[4, 2]              = "Summary of " + 
                                                             LbxDataToAge.SelectedItem.ToString();

            // Write the names and values of our aging buckets.
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
            
            // perform some formatting to ensure good readability of the final file.
            ExcelThread.Worksheet.Range["A:A"].ColumnWidth            = 13;
            ExcelThread.Worksheet.Range["B:B"].ColumnWidth            = 16;
            ExcelThread.Worksheet.Range["A4:A13"].HorizontalAlignment = HorizontalAlignment.Center;
            ExcelThread.Worksheet.Range["B5:B13"].NumberFormat        = "_($* #,##0.00_)";
            
            // finally write our file from memory to our location on disk. 
            ExcelThread.Workbook.SaveAs(saveFileDialog.FileName);
        }
    }
}
