using Newtonsoft.Json;

namespace MAL_Reviewer_API.models
{
    /// <summary>
    /// The information regarding an individual Anime.
    /// </summary>
    public class AnimeModel : TargetModel
    {
        /// <summary>
        /// The airing status of an Anime.
        /// </summary>
        [JsonProperty(PropertyName = "airing")]
        public bool Airing { get; set; }

        /// <summary>
        /// The number of episodes in an Anime.
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public int? Episodes { get; set; }
    }
}
