using System;
using MAL_Reviewer_API;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The heart of the application.
    /// </summary>
    public static class Core
    {
        #region Fields

        /// <summary>
        ///  The path to the storage location.
        /// </summary>
        public static readonly string StoragePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        #endregion

        #region Properties

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
            // Saving the settings.
            Settings.SaveSettings();
        }

        /// <summary>
        /// Loads all of the application's data.
        /// </summary>
        public static void LoadSettings()
        {
            // Initializing the settings.
            Settings.Init();
        }

        #endregion
    }
}
