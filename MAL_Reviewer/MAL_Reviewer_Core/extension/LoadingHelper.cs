using MAL_Reviewer_API.models.UserModels;
using MAL_Reviewer_Core.models.UserModels;

namespace MAL_Reviewer_Core.extension
{
    /// <summary>
    /// A helper for easily loading data into objects.
    /// </summary>
    public static class LoadingHelper
    {
        /// <summary>
        /// Loads data from one object to the another.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="MALuser"></param>
        public static void Load(this UserModel @this, MALUserModel MALuser)
        {
            @this.Username = MALuser.Username;
            @this.Gender = MALuser.Gender;
            @this.Location = MALuser.Location;
            @this.About = MALuser.About;

            @this.Birthday = MALuser.Birthday;
            @this.Joined = MALuser.Joined;

            @this.Url = MALuser.Url;
            @this.Image_url = MALuser.Image_url;
        }
    }
}
