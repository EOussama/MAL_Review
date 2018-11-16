using MAL_Reviewer_API;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The heart of the application.
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// The application's settings.
        /// </summary>
        public static Settings Settings;

        /// <summary>
        /// Initializes the intern functionalities of the application.
        /// </summary>
        public static void Init()
        {
            // Instanciation
            Settings = new Settings();

            // Initializing the MAL API helper.
            MALHelper.Init();

            // Initializing the settings.
            Settings.Init();
        }
    }
}
