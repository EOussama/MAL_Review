using System;
using System.Windows.Forms;

namespace MAL_Reviwer_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MAL_Reviwer_UI.forms.fNewReview());
        }
    }
}
