using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.ListEntryModels
{
    /// <summary>
    /// The user's Anime list information.
    /// </summary>
    public class AnimelistEntryResultsModel
    {
        /// <summary>
        /// Anime list.
        /// </summary>
        [JsonProperty(PropertyName = "anime")]
        public AnimelistEntryModel[] Anime { get; set; }
    }
}
