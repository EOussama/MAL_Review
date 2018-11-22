using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.UserModels
{
    /// <summary>
    /// The Manga stats of the user.
    /// </summary>
    public class MangaStatsModel : TargetStatsModel
    {
        /// <summary>
        /// The time spent reading Manga in days by the user.
        /// </summary>
        [JsonProperty(PropertyName = "days_read")]
        public double? Days_read { get; set; }

        /// <summary>
        /// The total number of Manga the user is currently reading.
        /// </summary>
        [JsonProperty(PropertyName = "reading")]
        public int? Reading { get; set; }

        /// <summary>
        /// The total number of Manga the user plans to read.
        /// </summary>
        [JsonProperty(PropertyName = "plan_to_read")]
        public int? Plan_to_read { get; set; }

        /// <summary>
        /// The total number of rereads of the user.
        /// </summary>
        [JsonProperty(PropertyName = "reread")]
        public int? Reread { get; set; }

        /// <summary>
        /// The total number of chapters read by the user.
        /// </summary>
        [JsonProperty(PropertyName = "chapters_read")]
        public int? Chapters_read { get; set; }

        /// <summary>
        /// The total number of volumes read by the user.
        /// </summary>
        [JsonProperty(PropertyName = "volumes_read")]
        public int? Volumes_read { get; set; }
    }
}
