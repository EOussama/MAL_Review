using MAL_Reviewer_Core.controllers;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The application's settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Initializing the settings.
        /// </summary>
        public static void Init()
        {
            // Seeding default settings.
            SeedSettings();
        }

        /// <summary>
        /// Loads stored settings to the memory into the memory.
        /// </summary>
        public static void LoadSettings()
        {
            
        }

        /// <summary>
        /// Saves the settings in the memory into a binary file.
        /// </summary>
        public static void SaveSettings()
        {

        }

        /// <summary>
        /// Generates default setting values for when the application first runs,
        /// also when a global reset is needed.
        /// </summary>
        public static void SeedSettings()
        {
            // Seeding review template settings.
            ReviewTemplatesController.SeedSettings();
        }
    }
}
