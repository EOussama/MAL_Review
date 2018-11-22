using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.SearchModels
{
    /// <summary>
    /// The information regarding a search entry.
    /// </summary>
    public class SearchResultsModel
    {
        /// <summary>
        /// The id of an Anime/Manga on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "mal_id")]
        public int Mal_id { get; set; }

        /// <summary>
        /// The title of an Anime/Manga.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The type of an Anime/Manga.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The url of the cover of an Anime/Manga.
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string Image_url { get; set; }
    }
}
