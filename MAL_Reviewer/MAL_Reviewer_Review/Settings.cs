using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MAL_Reviewer_Core.controllers;
using MAL_Reviewer_Core.interfaces;

namespace MAL_Reviewer_Core
{
    [Serializable]
    /// <summary>
    /// The application's settings.
    /// </summary>
    public class Settings : ISettings
    {
        #region Fields

        // The settings storage file's name.
        private const string StorageFile = "settings.dat";

        #endregion

        #region Properties

        /// <summary>
        /// The review template's settings.
        /// </summary>
        public ReviewTemplatesController ReviewTemplatesSettings { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Settings()
        {
            this.ReviewTemplatesSettings = new ReviewTemplatesController();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Loads stored settings to the memory into the memory.
        /// </summary>
        public void LoadSettings()
        {
            if (Core.Configurations.DoesStorageFileExist(StorageFile))
            {
                // Loading the review template's settings.
                IFormatter binaryFormatter = new BinaryFormatter();
                Stream fileStream = new FileStream(Path.Combine(Core.Configurations.StoragePath, Core.Configurations.StorageFolder, StorageFile), FileMode.Open, FileAccess.Read, FileShare.None);

                // Loading the data.
                Settings loadedData = (Settings)binaryFormatter.Deserialize(fileStream);
                ReviewTemplatesSettings = loadedData.ReviewTemplatesSettings;

                fileStream.Close();
            }
            else
            {
                SeedSettings();
            }
        }

        /// <summary>
        /// Saves the settings in the memory into a binary file.
        /// </summary>
        public void SaveSettings()
        {
            // Saving the review template's settings.
            IFormatter binaryFormatter = new BinaryFormatter();
            Stream fileStream = new FileStream(Path.Combine(Core.Configurations.StoragePath, Core.Configurations.StorageFolder, StorageFile), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            binaryFormatter.Serialize(fileStream, this);
            fileStream.Close();
        }

        /// <summary>
        /// Generates default setting values for when the application first runs,
        /// also when a global reset is needed.
        /// </summary>
        public void SeedSettings()
        {
            // Seeding review template settings.
            this.ReviewTemplatesSettings.SeedSettings();
        }

        /// <summary>
        /// Resets the application's settings
        /// </summary>
        public void ResetSettings()
        {
            // Resetting the review template's settings.
            this.ReviewTemplatesSettings.ResetSettings();
        }

        #endregion
    }
}
