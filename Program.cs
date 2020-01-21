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
