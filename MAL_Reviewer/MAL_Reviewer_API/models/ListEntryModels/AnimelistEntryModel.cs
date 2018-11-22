using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.ListEntryModels
{
    /// <summary>
    /// The individual Anime information (Part of the Anime list).
    /// </summary>
    public class AnimelistEntryModel : ListEntryModel
    {
        /// <summary>
        /// The Anime's watching status, (ex; Watching, Completed, On Hold, Dropped, Plant to Watch).
        /// </summary>
        [JsonProperty(PropertyName = "watching_status")]
        public short? Watching_status { get; set; }

        /// <summary>
        /// The number of watched episodes.
        /// </summary>
        [JsonProperty(PropertyName = "watched_episodes")]
        public short? Watched_episodes { get; set; }

        /// <summary>
        /// The number of episodes in a given Anime.
        /// </summary>
        [JsonProperty(PropertyName = "total_episodes")]
        public short? Total_episodes { get; set; }
    }
}
