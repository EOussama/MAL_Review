using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.ListEntryModels
{
    /// <summary>
    /// The individual Anime/Manga information, (Part of Anime/Manga list).
    /// </summary>
    public class ListEntryModel
    {
        /// <summary>
        /// The title of a given entry; (Anime/Manga).
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The url of the manga page on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The url of the manga's cover.
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string Image_url { get; set; }

        /// <summary>
        /// The type of a given entry, (ex; Anime, Movie, OVA, ONA, Special, Manga, Manwah, Novel, One Shot...).
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The score of the entry in MAL.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public byte? Score { get; set; }
    }
}
