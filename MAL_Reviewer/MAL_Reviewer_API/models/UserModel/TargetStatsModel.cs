using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.UserModel
{
    /// <summary>
    /// The Anime/Manga stats of the user.
    /// </summary>
    public class TargetStatsModel
    {
        /// <summary>
        /// The average Anime/Manga score of a user.
        /// </summary>
        [JsonProperty(PropertyName = "mean_score")]
        public double? Mean_score { get; set; }

        /// <summary>
        /// The number of completed Anime/Manga of a user.
        /// </summary>
        [JsonProperty(PropertyName = "completed")]
        public int? Completed { get; set; }

        /// <summary>
        /// The number of on hold Anime/Manga of a user.
        /// </summary>
        [JsonProperty(PropertyName = "on_hold")]
        public int? On_hold { get; set; }

        /// <summary>
        /// The number of dropped Anime/Manga of a user.
        /// </summary>
        [JsonProperty(PropertyName = "dropped")]
        public int? Dropped { get; set; }

        /// <summary>
        /// The number Anime/Manga of a user.
        /// </summary>
        [JsonProperty(PropertyName = "total_entries")]
        public int? Total_entries { get; set; }
    }
}
