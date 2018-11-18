using System;
using MAL_Reviewer_Core;

namespace MAL_Reviewer_Sandbox
{
    /// <summary>
    /// The sandbox environment aimed at testing the individual parts of the application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Core.Settings.ReviewTemplatesSettings.ReviewTemplates[0].TemplateName);

            // Stoping the test.
            Console.ReadKey();
        }
    }
}
