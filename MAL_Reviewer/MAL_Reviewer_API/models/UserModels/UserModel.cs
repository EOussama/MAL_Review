using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MAL_Reviewer_API.models.ListEntryModels;

namespace MAL_Reviewer_API.models.UserModels
{
    /// <summary>
    /// The user's information on MAL.
    /// </summary>
    public class MALUserModel
    {
        /// <summary>
        /// The user's name.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// The user's MAL page's url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The user's image url.
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string Image_url { get; set; }

        /// <summary>
        /// The user's gender.
        /// </summary>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The user's location.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        
        /// <summary>
        /// The user's about.
        /// </summary>
        [JsonProperty(PropertyName = "about")]
        public string About { get; set; }

        /// <summary>
        /// The user's birthdate.
        /// </summary>
        [JsonProperty(PropertyName = "birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// The user's joining date.
        /// </summary>
        [JsonProperty(PropertyName = "joined")]
        public DateTime? Joined { get; set; }

        /// <summary>
        /// The user's Anime stats.
        /// </summary>
        [JsonProperty(PropertyName = "anime_stats")]
        public AnimeStatsModel Anime_stats { get; set; }

        /// <summary>
        /// The user's Manga stats.
        /// </summary>
        [JsonProperty(PropertyName = "manga_stats")]
        public MangaStatsModel Manga_stats { get; set; }

        /// <summary>
        /// The user's favorite Anime/Manga/characters/people list.
        /// </summary>
        [JsonProperty(PropertyName = "favorites")]
        public FavoritesModel Favorites { get; set; }

        /// <summary>
        /// The user's Anime list.
        /// </summary>
        [JsonProperty(PropertyName = "animeList")]
        public IEnumerable<AnimelistEntryModel> AnimeList { get; set; }

        /// <summary>
        /// The user's Manga list.
        /// </summary>
        [JsonProperty(PropertyName = "mangaList")]
        public IEnumerable<MangalistEntryModel> MangaList { get; set; }
    }
}
