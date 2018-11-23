using MAL_Reviewer_API;
using MAL_Reviewer_Core.models.UserModels;

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

        /// <summary>
        /// The currently connected MAL user.
        /// </summary>
        public static UserModel User { get; set; } = null;

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes the intern functionalities of the application.
        /// </summary>
        public static void Init()
        {
            // Instantiation
            Configurations = new Config();
            Settings = new Settings();
            User = null;

            // Loading the data.
            Load();

            // Initializing the MAL API helper.
            MALHelper.Init();
        }

        /// <summary>
        /// Saves all of the application's data.
        /// </summary>
        public static void Save()
        {
            // Create the storage folder if it doesn't exist.
            Configurations.PrepareStorageFolder();

            // Saving the settings.
            Settings.SaveSettings();
        }

        /// <summary>
        /// Loads all of the application's data.
        /// </summary>
        public static void Load()
        {
            // Create the storage folder if it doesn't exist.
            Configurations.PrepareStorageFolder();

            // Loading the settings.
            Settings.LoadSettings();
        }

        #endregion
    }
}
