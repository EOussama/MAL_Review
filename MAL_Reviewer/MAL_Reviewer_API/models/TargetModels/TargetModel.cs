using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.TargetModels
{
    /// <summary>
    /// The information regarding an individual Anime/Manga.
    /// </summary>
    public class TargetModel
    {
        /// <summary>
        /// The id of an Anime/Manga on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "mal_id")]
        public int Mal_id { get; set; }
        
        /// <summary>
        /// The url of the page of an Anime/Manga on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The url of the image of the Anime/Manga's cover.
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string Image_url { get; set; }

        /// <summary>
        /// The entry's title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The entry's type; (Anime, OVA, ONA, Movie, Special, Manga, Manwha, One Shot, Nover...).
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The score of the entry on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public float? Score { get; set; }

        /// <summary>
        /// The rank of the entry on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int? Rank { get; set; }

        /// <summary>
        /// The synopsis of the entry on MAL.
        /// </summary>
        [JsonProperty(PropertyName = "synopsis")]
        public string Synopsis { get; set; }
    }
}
