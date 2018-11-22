using MAL_Reviewer_API;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The heart of the application.
    /// </summary>
    public static class Core
    {
        #region Properties

        /// <summary>
        /// The application's configurations.
        /// </summary>
        public static Config Configurations { get; set; }

        /// <summary>
        /// The application's settings.
        /// </summary>
        public static Settings Settings { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes the intern functionalities of the application.
        /// </summary>
        public static void Init()
        {
            // Instanciation
            Configurations = new Config();
            Settings = new Settings();

            // Initializing the settings.
            LoadSettings();

            // Initializing the MAL API helper.
            MALHelper.Init();
        }

        /// <summary>
        /// Saves all of the application's data.
        /// </summary>
        public static void SaveSettings()
        {
            // Create the storage folder if it doesn't exist.
            Configurations.PrepareStorageFolder();

            // Saving the settings.
            Settings.SaveSettings();
        }

        /// <summary>
        /// Loads all of the application's data.
        /// </summary>
        public static void LoadSettings()
        {
            // Create the storage folder if it doesn't exist.
            Configurations.PrepareStorageFolder();

            // Loading the settings.
            Settings.LoadSettings();
        }

        #endregion
    }
}
