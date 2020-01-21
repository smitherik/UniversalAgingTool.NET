
using System;
using System.Windows.Forms;

namespace universalAgingTool
{
    public partial class ViewAgedData : Form
    {
        public ViewAgedData(string file, DateTime date, string dateColumn, string valueColumn, AgedDataStore data)
        {
            InitializeComponent();
            string header1    = "Aging results for file " + file;
            string header2    = "being performed on " + dateColumn + " from " + date.ToString("MM/dd/yyyy");
            string sumValHead = "Summary of " + valueColumn;

            LblFooter.Text         = DateTime.Now.ToString();
            LblHeader1.Text        = header1;
            LblHeader2.Text        = header2;
            LblHeaderSumValue.Text = sumValHead;
            LblBucket1.Text        = data.Day0To30.ToString();
            LblBucket2.Text        = data.Day31To60.ToString();
            LblBucket3.Text        = data.Day61To90.ToString();
            LblBucket4.Text        = data.Day91To120.ToString();
            LblBucket5.Text        = data.Day121To150.ToString();
            LblBucket6.Text        = data.Day151To180.ToString();
            LblBucket7.Text        = data.Day181To270.ToString();
            LblBucket8.Text        = data.Day271To360.ToString();
            LblBucket9.Text        = data.Day361Plus.ToString();
        }
    }
}
