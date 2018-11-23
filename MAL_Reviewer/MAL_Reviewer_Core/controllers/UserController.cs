using System;
using MAL_Reviewer_Core.interfaces;
using MAL_Reviewer_Core.models.UserModels;

namespace MAL_Reviewer_Core.controllers
{
    [Serializable]
    /// <summary>
    /// The controller of the user.
    /// </summary>
    public class UserController : ISettings
    {
        #region Properties

        /// <summary>
        /// The default MAL user.
        /// </summary>
        public string DefaultUser { get; set; } = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public UserController() { }

        #endregion

        #region Public methods       

        /// <summary>
        /// Resets the user's settings.
        /// </summary>
        public void ResetSettings()
        {
            SeedSettings();
        }

        /// <summary>
        /// Generate default values for the user's settings.
        /// </summary>
        public void SeedSettings()
        {
            DefaultUser = string.Empty;
        }

        #endregion
    }
}
