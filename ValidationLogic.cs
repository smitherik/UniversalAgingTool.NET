/*-----------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    This class contains all the logic used for state validation 
               within the AgingTool form. All methods shall return a boolean
               and are intended to be called without object instaciation.
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
    class ValidationLogic
    {
        public static bool InvalidFile(TextBox txtBx)
        {
            string extension = "xlsx";
            string file      = txtBx.Text.ToString();
            bool   validFile = file.Contains(extension);
            
            return !validFile;
        }

        public static bool NoItemSelected(ListBox lstBx)
        {
            return lstBx.SelectedItem is null;
        }

        public static bool NoColumnsFound(Microsoft.Office.Interop.Excel.Worksheet wkSht)
        {
            Microsoft.Office.Interop.Excel.Range xlData = wkSht.UsedRange;
            int colCount = xlData.Columns.Count;
            if (colCount < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DateInvalid(DateTime date)
        {
            return  date > DateTime.Today;
        }

        public static bool ColumnsNotSelected(ListBox col1, ListBox col2)
        {
            return col1.SelectedItem is null || col2.SelectedItem is null;
        }
    }
}
