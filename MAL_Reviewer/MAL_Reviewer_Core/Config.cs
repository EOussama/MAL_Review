using System;
using System.IO;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The application's configurations.
    /// </summary>
    public class Config
    {
        #region Fields

        /// <summary>
        /// The default path to the storage location.
        /// </summary>
        public readonly string StoragePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// The default storage folder's name.
        /// </summary>
        public readonly string StorageFolder = "MAL_Reviewer";

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Config() { }

        #endregion

        #region Public methods

        /// <summary>
        /// Creates the storage folder if it doesn't exist.
        /// </summary>
        public void PrepareStorageFolder()
        {
            if (!Directory.Exists(Path.Combine(Core.Configurations.StoragePath, Core.Configurations.StorageFolder)))
            {
                Directory.CreateDirectory(Path.Combine(Core.Configurations.StoragePath, Core.Configurations.StorageFolder));
            }
        }

        /// <summary>
        /// Checks if the file where the data resides exists.
        /// </summary>
        /// <returns></returns>
        public bool DoesStorageFileExist(string file)
        {
            return File.Exists(Path.Combine(Core.Configurations.StoragePath, Core.Configurations.StorageFolder, file));
        }

        #endregion
    }
}
