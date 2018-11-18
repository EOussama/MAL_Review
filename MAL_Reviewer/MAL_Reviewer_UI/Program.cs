using System;
using System.Windows.Forms;
using MAL_Reviewer_Core;

namespace MAL_Reviewer_UI
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

            // Initializing the application's core.
            Core.Init();

            // Application shutdown event
            Application.ApplicationExit += (s, e) =>
            {
                // Saving global settings.
                Core.SaveSettings();
            };

            Application.Run(new forms.WelcomeForm());
        }
    }
}
