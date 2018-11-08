using Newtonsoft.Json;

namespace MAL_Reviewer_API.models
{
    /// <summary>
    /// The Anime stats of the user.
    /// </summary>
    public class AnimeStatsModel : models.UserModel.TargetStatsModel
    {
        /// <summary>
        /// The time spent watching Anime in days by the user.
        /// </summary>
        [JsonProperty(PropertyName = "days_watched")]
        public double? Days_watched { get; set; }

        /// <summary>
        /// The total number of Anime the user is currently watching.
        /// </summary>
        [JsonProperty(PropertyName = "watching")]
        public int? Watching { get; set; }

        /// <summary>
        /// The total number of Anime the user plans to watch.
        /// </summary>
        [JsonProperty(PropertyName = "plan_to_watch")]
        public int? Plan_to_watch { get; set; }

        /// <summary>
        /// The total number of rewatches of the user.
        /// </summary>
        [JsonProperty(PropertyName = "rewatched")]
        public int? Rewatched { get; set; }

        /// <summary>
        /// The total number of watched episodes by the user.
        /// </summary>
        [JsonProperty(PropertyName = "episodes_watched")]
        public int? Episodes_watched { get; set; }
    }
}
