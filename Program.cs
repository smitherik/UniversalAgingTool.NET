/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-21
    Purpose    Application entry point.
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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            // These three lines of code are required any changes MUST be comment documented.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AgingTool());
        }
    }
}
