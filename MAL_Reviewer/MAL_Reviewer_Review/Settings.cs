using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MAL_Reviewer_Core.controllers;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The application's settings.
    /// </summary>
    public static class Settings
    {
        /// The path where the storage folder is(should be) located.
        private static readonly string STORAGE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        ///  The storage folder and file.
        /// </summary>
        private const string
            STORAGE_FOLDER = "MAL_Reviewer",
            STORAGE_FILE = "settings.bat";

        /// <summary>
        /// Initializing the settings.
        /// </summary>
        public static void Init()
        {
            // Check if the storage folder exists.
            if (DoesStorageFolderExist())
            {
                // Check if storage file exists.
                if (!DoesStorageFileExist())
                {
                    // Seeding default settings.
                    SeedSettings();

                    // Serializing the data.
                }
                else
                {
                    // Load
                }
            }
            else
            {
                // Creating the storage folder.
                Directory.CreateDirectory(Path.Combine(STORAGE_PATH, STORAGE_FOLDER));

                // Seeding default settings.
                SeedSettings();

                // Serializing the data.
                using (FileStream fileStream = new FileStream(Path.Combine(STORAGE_PATH, STORAGE_FILE), FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    binaryFormatter.Serialize(fileStream, "");
                    fileStream.Close();
                }
            }
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

        /// <summary>
        /// Check if the folder where the data resides exists.
        /// </summary>
        /// <returns></returns>
        public static bool DoesStorageFolderExist()
        {
            return Directory.Exists(Path.Combine(STORAGE_PATH, STORAGE_FOLDER));
        }

        /// <summary>
        /// Check if the file where the data resides exists.
        /// </summary>
        /// <returns></returns>
        public static bool DoesStorageFileExist()
        {
            return File.Exists(Path.Combine(STORAGE_PATH, STORAGE_FILE));
        }
    }
}
