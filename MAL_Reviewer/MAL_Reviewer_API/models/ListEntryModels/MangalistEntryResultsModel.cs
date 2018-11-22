using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.ListEntryModels
{
    /// <summary>
    /// The user's Manga list information.
    /// </summary>
    class MangalistEntryResultsModel
    {
        /// <summary>
        /// Anime list.
        /// </summary>
        [JsonProperty(PropertyName = "manga")]
        public MangalistEntryModel[] Manga { get; set; }
    }
}
