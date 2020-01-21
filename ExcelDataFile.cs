namespace universalAgingTool
{
    public class ExcelDataFile
    {
        public Microsoft.Office.Interop.Excel.Application  App        { get; set; }
        public Microsoft.Office.Interop.Excel.Workbook     Workbook   { get; set; }
        public Microsoft.Office.Interop.Excel.Sheets       Worksheets { get; set; }
        public Microsoft.Office.Interop.Excel.Worksheet    Worksheet  { get; set; }
        public Microsoft.Office.Interop.Excel.Range        DataSet    { get; set; }

        public ExcelDataFile()
        {
            this.App = new Microsoft.Office.Interop.Excel.Application();
        }

        public void Shutdown()
        {
            try
            {
                this.Workbook.Close(false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
            }
            catch (System.NullReferenceException)
            {
                /* do not let the system crash if no workbook is currently set
                 * during the shutting down of the application
                 */
            }
            try
            {
                this.App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(App);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("If you are seeing this then I clearly did something wrong... please contact Erik S.");
            }
        }

        public void OpenWorkbook(string file)
        {
            this.Workbook = this.App.Workbooks.Open(file);
        }

        public void GetSheets()
        {
            this.Worksheets = this.Workbook.Sheets;
        }

        public void Reset()
        {
            this.DataSet = default;
            this.Worksheet = default;
            this.Worksheets = default;
            try
            {
                this.Workbook.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
            }
            catch (System.NullReferenceException)
            {
            }
            this.Workbook = default;

        }
        
    }
}
