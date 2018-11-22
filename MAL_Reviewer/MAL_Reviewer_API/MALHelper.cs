using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MAL_Reviewer_API.models.SearchModels;
using MAL_Reviewer_API.models.ListEntryModels;
using MAL_Reviewer_API.models.TargetModels;
using MAL_Reviewer_API.models.UserModels;

namespace MAL_Reviewer_API
{
    public static class MALHelper
    {
        private static HttpClient client;

        /// <summary>
        /// Initializing the HTTPClient
        /// </summary>
        public static void Init()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://api.jikan.moe/v3/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Responsible on searching for results that have to do with the passed arguments and returning them back.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <returns> Task<SearchModel> </returns>
        public async static Task<SearchModel> Search(string type, string title, CancellationToken ct)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }search/{ type }?q={ title }&page=1&limit=10";
            HttpResponseMessage response = await client.GetAsync(url);

            ct.ThrowIfCancellationRequested();

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<SearchModel>();

            return null;
        }

        /// <summary>
        /// Retrieves the anime of the matching id.
        /// </summary>
        /// <param name="animeId"></param>
        /// <returns></returns>
        public async static Task<AnimeModel> GetAnime(int animeId)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }anime/{ animeId }";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<AnimeModel>();

            return null;
        }

        /// <summary>
        /// Retrieves the manga of the matching id.
        /// </summary>
        /// <param name="mangaId"></param>
        /// <returns></returns>
        public async static Task<MangaModel> GetManga(int mangaId)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }manga/{ mangaId }";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<MangaModel>();

            return null;
        }


        /// <summary>
        /// Retrieves information of the given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async static Task<MALUserModel> GetUser(string username, CancellationToken ct)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }";
            HttpResponseMessage response = await client.GetAsync(url);

            ct.ThrowIfCancellationRequested();

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<MALUserModel>();

            return null;
        }

        /// <summary>
        /// Retrieves the given user's animelist.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="totalEntries"></param>
        /// <returns></returns>
        public async static Task<List<AnimelistEntryModel>> GetAnimeList(string username, int totalEntries, CancellationToken ct)
        {
            int pages = (int)Math.Ceiling((decimal)totalEntries / 300);
            List<AnimelistEntryModel> animeList = new List<AnimelistEntryModel>();

            foreach (int i in System.Linq.Enumerable.Range(1, pages))
            {
                string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }/animelist/all/{ i }";
                HttpResponseMessage response = await client.GetAsync(url);

                ct.ThrowIfCancellationRequested();

                if (response.IsSuccessStatusCode)
                {
                    AnimelistEntryResultsModel results = await response.Content.ReadAsAsync<AnimelistEntryResultsModel>();

                    foreach (AnimelistEntryModel anime in results.Anime)
                        animeList.Add(anime);
                }
                else
                {
                    animeList = null;
                }
            }

            return animeList;
        }

        /// <summary>
        /// Retrieves the given user's mangalist.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="totalEntries"></param>
        /// <returns></returns>
        public async static Task<List<MangalistEntryModel>> GetMangaList(string username, int totalEntries, CancellationToken ct)
        {
            int pages = (int)Math.Ceiling((decimal)totalEntries / 300);
            List<MangalistEntryModel> mangaList = new List<MangalistEntryModel>();

            foreach (int i in System.Linq.Enumerable.Range(1, pages))
            {
                string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }/mangalist/all/{ i }";
                HttpResponseMessage response = await client.GetAsync(url);

                ct.ThrowIfCancellationRequested();

                if (response.IsSuccessStatusCode)
                {
                    MangalistEntryResultsModel results = await response.Content.ReadAsAsync <MangalistEntryResultsModel>();

                    foreach (MangalistEntryModel manga in results.Manga)
                        mangaList.Add(manga);
                }
                else
                {
                    mangaList = null;
                }
            }

            return mangaList;
        }
    }
}
