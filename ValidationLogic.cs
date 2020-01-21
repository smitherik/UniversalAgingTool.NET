using System;
using System.Windows.Forms;


namespace universalAgingTool
{
    class ValidationLogic
    {
        public static bool InvalidFile(TextBox txtBx)
        {
            string extension = "xlsx";
            string file = txtBx.Text.ToString();
            bool validFile = file.Contains(extension);
            return !validFile;
        }

        public static bool NoItemSelected(ListBox lstBx)
        {
            bool noSheetSelected = false;
            try
            {
                lstBx.SelectedItem.ToString();
            }
            catch (System.NullReferenceException)
            {
                noSheetSelected = true;
            }
            return noSheetSelected;
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
            bool noColsSelected = false;
            try
            {
                col1.SelectedItem.ToString();
                col2.SelectedItem.ToString();
            }
            catch (System.NullReferenceException)
            {
                noColsSelected = true;
            }
            return noColsSelected;
        }
    }
}
