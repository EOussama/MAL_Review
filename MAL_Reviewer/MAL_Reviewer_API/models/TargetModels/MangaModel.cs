using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.TargetModels
{
    /// <summary>
    /// The information regarding an individual Manga.
    /// </summary>
    public class MangaModel : TargetModel
    {
        /// <summary>
        /// The publishing status of the Manga.
        /// </summary>
        [JsonProperty(PropertyName = "publishing")]
        public bool Publishing { get; set; }

        /// <summary>
        /// The number of volumes in the Manga.
        /// </summary>
        [JsonProperty(PropertyName = "volumes")]
        public int? Volumes { get; set; }

        /// <summary>
        /// The number of chapters in the Manga.
        /// </summary>
        [JsonProperty(PropertyName = "chapters")]
        public int? Chapters { get; set; }
    }
}
