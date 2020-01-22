/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    Class to be used to hold all the pertanent information for
               accessing and controling an Excel COM object. All file access is
               intended to be performed through this class fields and methods. 
-------------------------------------------------------------------------------
    Modification History
  
    01/21/2020  Erik W. Smith
    [1:eof]
        Initial development.
-----------------------------------------------------------------------------*/
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
            // upon instanciation attach an excel process/thread to be used for the 
            // remainder of the time the application remaines open. 
            this.App = new Microsoft.Office.Interop.Excel.Application();
        }

        public void Shutdown()
        {
            if (!(Workbook is null))
            {
                Workbook.Close(false);
                // COM object release required to not leave file locked. 
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
            }
            this.App.Quit();
            // COM object release required to not leave file locked. 
            System.Runtime.InteropServices.Marshal.ReleaseComObject(App);
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
            this.DataSet    = default;
            this.Worksheet  = default;
            this.Worksheets = default;
            if (!(Workbook is null))
            {
                Workbook.Close(false);
                // COM object release required to not leave file locked. 
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook);
            }
            this.Workbook = default;

        }
        
    }
}
