using System;
using System.Collections.Generic;
using MAL_Reviewer_API.models.ListEntryModel;

namespace MAL_Reviewer_API.models
{
    public class MALUserModel
    {
        public string username;
        public string url;
        public string image_url;
        public string gender;
        public string location;
        public string about;
        public DateTime? birthday;
        public DateTime? joined;
        public AnimeStatsModel anime_stats;
        public MangaStatsModel manga_stats;
        public FavoritesModel favorites;
        public List<AnimelistEntryModel> animeList;
        public List<MangalistEntryModel> mangaList;
    }
}
