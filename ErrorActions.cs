/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    this is designed to be used such that any specific actions
               that need to occur upon reaching an error state are contained
               within the methods of this class. 
-------------------------------------------------------------------------------
    Modification History
  
    01/21/2020  Erik W. Smith
    [1:eof]
        Basically a place holder for message box calls for the time being.
        Class is being included to support future error state action 
        development.
-----------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace universalAgingTool
{
    class ErrorActions
    {
        public static void InvalidFile()
        {
            MessageBox.Show("Please select a file for processing. Take note this tool only suppports .xlsx filetypes");
        }

        public static void NoSheetSelected()
        {
            MessageBox.Show("Please select a sheet from the list.");
        }

        public static void NoColumnsFound()
        {
            MessageBox.Show("Not enough columns found in selected sheet.");
        }

        public static void FailOpenFile()
        {
            MessageBox.Show("Oops, something went wrong and the file you selected was unable to be opened.");
        }

        public static void HeaderNotAnswered()
        {
            MessageBox.Show("Please select Yes or No from the drop down indicating if headers are contained within the file.");
        }

        public static void DateInFuture()
        {
            MessageBox.Show("Please select a date equal or prior to today.");
        }

        public static void ColumnsNotSelected()
        {
            MessageBox.Show("Please select both a column holding the date to be aged by and the column holding the data to be summrized.");
        }
        
        public static void InvalidDataType()
        {

        }

        public static void InvalidValue()
        {

        }
    }
}
