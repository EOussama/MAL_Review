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
        private const string
            // The settings storage folder's name.
            StorageFolder = "MAL_Reviewer",

            // The settings storage file's name.
            StorageFile = "settings.dat";

        /// <summary>
        /// The review template's settings.
        /// </summary>
        public ReviewTemplatesController ReviewTemplatesSettings { get; set; }

        /// <summary>
        ///  The storage folder and file.
        /// </summary>
        

        /// <summary>
        /// Constructor.
        /// </summary>
        public Settings()
        {
            this.ReviewTemplatesSettings = new ReviewTemplatesController();
        }

        /// <summary>
        /// Initializing the settings.
        /// </summary>
        public void Init()
        {
            // Check if the storage folder exists.
            if (DoesStorageFolderExist())
            {
                // Check if storage file exists.
                if (!DoesStorageFileExist())
                {
                    // Seeding default settings.
                    this.SeedSettings();

                    // Serializing the data.
                    this.SaveSettings();
                }
                else
                {
                    // Loading the settings into the memory.
                    this.LoadSettings();
                }
            }
            else
            {
                // Creating the storage folder.
                this.CreateStorageFolder();

                // Seeding default settings.
                this.SeedSettings();

                // Serializing the data.
                this.SaveSettings();
            }
        }

        /// <summary>
        /// Loads stored settings to the memory into the memory.
        /// </summary>
        public void LoadSettings()
        {
            // Loading the review template's settings.
            IFormatter binaryFormatter = new BinaryFormatter();
            Stream fileStream = new FileStream(Path.Combine(Core.StoragePath, StorageFolder, StorageFile), FileMode.Open, FileAccess.Read, FileShare.None);

            // Loading the data.
            Settings loadedData = (Settings) binaryFormatter.Deserialize(fileStream);
            this.ReviewTemplatesSettings = loadedData.ReviewTemplatesSettings;

            fileStream.Close();
        }

        /// <summary>
        /// Saves the settings in the memory into a binary file.
        /// </summary>
        public void SaveSettings()
        {
            // Saving the review template's settings.
            IFormatter binaryFormatter = new BinaryFormatter();
            Stream fileStream = new FileStream(Path.Combine(Core.StoragePath, StorageFolder, StorageFile), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

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
        /// Creates the storage folder.
        /// </summary>
        private void CreateStorageFolder()
        {
            Directory.CreateDirectory(Path.Combine(Core.StoragePath, StorageFolder));
        }

        /// <summary>
        /// Check if the folder where the data resides exists.
        /// </summary>
        /// <returns></returns>
        public static bool DoesStorageFolderExist()
        {
            return Directory.Exists(Path.Combine(Core.StoragePath, StorageFolder));
        }

        /// <summary>
        /// Check if the file where the data resides exists.
        /// </summary>
        /// <returns></returns>
        public static bool DoesStorageFileExist()
        {
            return File.Exists(Path.Combine(Core.StoragePath, StorageFolder, StorageFile));
        }
    }
}
