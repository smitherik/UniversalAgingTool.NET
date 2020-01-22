/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    In application display for the aging results.
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
    public partial class ViewAgedData : Form
    {
        // This form is intended to represent a in memory "report" for the user
        // and it was for this reason that I decided to require the data be 
        // passed into the report akin to a standard report. 
        public ViewAgedData(ResultsDataStruct results)
        {
            InitializeComponent();
            // Building the strings that will display communicate where the results
            // were calculated from. 
            string header1         = "Aging results for file " + 
                                     results.File;
            string header2         = "being performed on " + 
                                     results.DateColumn + 
                                     " from " + 
                                     results.Date.ToString("MM/dd/yyyy");
            string sumValHead      = "Summary of " + 
                                     results.ValueColumn;
            // Populate the report with our results and built strings. 
            LblFooter.Text         = DateTime.Now.ToString();
            LblHeader1.Text        = header1;
            LblHeader2.Text        = header2;
            LblHeaderSumValue.Text = sumValHead;
            LblBucket1.Text        = results.Data.Day0To30.ToString();
            LblBucket2.Text        = results.Data.Day31To60.ToString();
            LblBucket3.Text        = results.Data.Day61To90.ToString();
            LblBucket4.Text        = results.Data.Day91To120.ToString();
            LblBucket5.Text        = results.Data.Day121To150.ToString();
            LblBucket6.Text        = results.Data.Day151To180.ToString();
            LblBucket7.Text        = results.Data.Day181To270.ToString();
            LblBucket8.Text        = results.Data.Day271To360.ToString();
            LblBucket9.Text        = results.Data.Day361Plus.ToString();
        }
    }
}
