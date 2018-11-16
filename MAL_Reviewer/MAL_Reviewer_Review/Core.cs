using MAL_Reviewer_API;

namespace MAL_Reviewer_Core
{
    /// <summary>
    /// The heart of the application.
    /// </summary>
    public static class Core
    {
        public static void Init()
        {
            // Initializing the MAL API helper.
            MALHelper.Init();

            // Initializing the settings.
            Settings.Init();
        }
    }
}
