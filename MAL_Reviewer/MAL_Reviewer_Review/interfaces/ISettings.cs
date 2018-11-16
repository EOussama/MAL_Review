namespace MAL_Reviewer_Core.interfaces
{
    /// <summary>
    /// What every other sub-setting should map to
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Loads the settings to the memory.
        /// </summary>
        void LoadSettings();

        /// <summary>
        /// Saves the settings in the memory into a binary file.
        /// </summary>
        void SaveSettings();

        /// <summary>
        /// Generates default setting values for when the application first runs,
        /// also when a global reset is needed.
        /// </summary>
       void SeedSettings();
    }
}
