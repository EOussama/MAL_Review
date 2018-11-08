using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.ListEntryModel
{
    /// <summary>
    /// The individual Manga information, (Part of the Manga list).
    /// </summary>
    public class MangalistEntryModel : ListEntryModel
    {
        /// <summary>
        /// The Manga's reading status, (ex; Reading, Completed, On Hold, Dropped, Plant to Read).
        /// </summary>
        [JsonProperty(PropertyName = "reading_status")]
        public short? Reading_status { get; set; }

        /// <summary>
        /// The number of read chapters.
        /// </summary>
        [JsonProperty(PropertyName = "read_chapters")]
        public short? Read_chapters { get; set; }

        /// <summary>
        /// The number of read volumes.
        /// </summary>
        [JsonProperty(PropertyName = "read_volumes")]
        public short? Read_volumes { get; set; }

        /// <summary>
        /// The number of chapters in a given Manga.
        /// </summary>
        [JsonProperty(PropertyName = "total_chapters")]
        public short? Total_chapters { get; set; }

        /// <summary>
        /// The number of volumes in a given Manga.
        /// </summary>
        [JsonProperty(PropertyName = "total_volumes")]
        public short? Total_volumes { get; set; }
    }
}
