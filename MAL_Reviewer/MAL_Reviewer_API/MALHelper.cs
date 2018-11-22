using System;
using System.Linq;
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
    /// <summary>
    /// This is the entry point that enables fetching
    /// data from MAL (MyAnimeList) using the Jikan API.
    /// </summary>
    public static class MALHelper
    {
        #region Fields

        /// <summary>
        /// The URL to the Jikan API.
        /// </summary>
        private const string JikanURL = "https://api.jikan.moe/v3/";

        /// <summary>
        /// The HttpClient object that talks to the Jikan API.
        /// </summary>
        private static HttpClient client;

        #endregion

        #region Public methods

        /// <summary>
        /// Initializing the HTTPClient
        /// </summary>
        public static void Init()
        {
            // Instantiating the HttpClient object.
            client = new HttpClient
            {
                // Setting the default base address, pointing at the Jikan API.
                BaseAddress = new Uri(JikanURL)
            };

            // Setting the primary request headers.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Returns the search results from MAL given the passed target.
        /// </summary>
        /// <param name="type"> The type of the target; (Anime or Manga). </param>
        /// <param name="title"> The title of the target; (the Anime/Manga's title/name). </param>
        /// <param name="ct"> The cancellation token that permits the task's cancellation. </param>
        /// <returns> A list of search results depending on the set limit, 10 is the default. </returns>
        public async static Task<SearchResultsModel[]> Search(string type, string title, CancellationToken ct)
        {
            // Setting up the request's URL.
            string url = $"{ client.BaseAddress.AbsoluteUri }search/{ type }?q={ title }&page=1&limit=10";

            // Getting the response asynchronously.
            HttpResponseMessage response = await client.GetAsync(url);

            // Throwing the cancellation check.
            ct.ThrowIfCancellationRequested();

            // Checking if the data was successfully retrieved.
            if (response.IsSuccessStatusCode)
            {
                // Mapping the JSON data to the SearchModel object.
                SearchModel searchModel = await response.Content.ReadAsAsync<SearchModel>();

                // Returning the list of search results.
                return searchModel.Results;
            }

            // Returning null as a sign that data was not retrieved.
            return null;
        }

        /// <summary>
        /// Returns an Anime with the given passed MAL id.
        /// </summary>
        /// <param name="animeId"> The MAL id of the Anime. </param>
        /// <returns> The Anime's information mapped to the AnimeModel object. </returns>
        public async static Task<AnimeModel> GetAnime(int animeId)
        {
            // Setting up the request's URL.
            string url = $"{ client.BaseAddress.AbsoluteUri }anime/{ animeId }";

            // Getting the response asynchronously.
            HttpResponseMessage response = await client.GetAsync(url);

            // Checking if the data was successfully retrieved.
            if (response.IsSuccessStatusCode)
            {
                // Mapping the JSON data into an AnimeModel object and returning it.
                return await response.Content.ReadAsAsync<AnimeModel>();
            }

            // Returning null as a sign that data was not retrieved.
            return null;
        }

        /// <summary>
        /// Returns a Manga with the given passed MAL id.
        /// </summary>
        /// <param name="mangaId"> The MAL id of the Manga. </param>
        /// <returns> The Manga's information mapped to the MangaModel object. </returns>
        public async static Task<MangaModel> GetManga(int mangaId)
        {
            // Setting up the request's URL.
            string url = $"{ client.BaseAddress.AbsoluteUri }manga/{ mangaId }";

            // Getting the response asynchronously.
            HttpResponseMessage response = await client.GetAsync(url);

            // Checking if the data was successfully retrieved.
            if (response.IsSuccessStatusCode)
            {
                // Mapping the JSON data into a MangaModel object and returning it.
                return await response.Content.ReadAsAsync<MangaModel>();
            }

            // Returning null as a sign that data was not retrieved.
            return null;
        }

        /// <summary>
        /// Returns a user with the given passed MAL username.
        /// </summary>
        /// <param name="username"> The user's name. </param>
        /// <param name="ct"> The cancellation token that permits the task's cancellation. </param>
        /// <returns> A MALUserModel containing information about the user. </returns>
        public async static Task<MALUserModel> GetUser(string username, CancellationToken ct)
        {
            // Setting up the request's URL.
            string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }";

            // Getting the response asynchronously.
            HttpResponseMessage response = await client.GetAsync(url);

            // Throwing the cancellation check.
            ct.ThrowIfCancellationRequested();

            // Checking if the data was successfully retrieved.
            if (response.IsSuccessStatusCode)
            {
                // Mapping the JSON data into a MALUserModel object and returning it.
                return await response.Content.ReadAsAsync<MALUserModel>();
            }

            // Returning null as a sign that data was not retrieved.
            return null;
        }

        /// <summary>
        /// Returns the Anime list of the given passed username.
        /// </summary>
        /// <param name="username"> The user's name. </param>
        /// <param name="totalEntries"> The total Anime entries of the user. </param>
        /// <param name="ct"> The cancellation token that permits the task's cancellation. </param>
        /// <returns> A list of the user's Anime entries. </returns>
        public async static Task<IEnumerable<AnimelistEntryModel>> GetAnimeList(string username, int totalEntries, CancellationToken ct)
        {
            // Getting the number of pages of the user's Anime list.
            int pages = (int)Math.Ceiling((decimal)totalEntries / 300);

            // Instaltiating the list that will temporarely hold the retrieved Anime entries.
            List<AnimelistEntryModel> animeList = new List<AnimelistEntryModel>();

            // Lopping through the pages of the user's Anime list.
            foreach (int i in Enumerable.Range(1, pages))
            {
                // Setting up the request's URL.
                string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }/animelist/all/{ i }";

                // Getting the response asynchronously.
                HttpResponseMessage response = await client.GetAsync(url);

                // Throwing the cancellation check.
                ct.ThrowIfCancellationRequested();

                // Checking if the data was successfully retrieved.
                if (response.IsSuccessStatusCode)
                {
                    // Mapping the JSON data into an AnimelistEntryResultsModel object.
                    AnimelistEntryResultsModel results = await response.Content.ReadAsAsync<AnimelistEntryResultsModel>();

                    // Looping through the Anime entries in the retrieved list.
                    foreach (AnimelistEntryModel anime in results.Anime)
                    {
                        // Adding the Anime to the temporary list.
                        animeList.Add(anime);
                    }
                }
                else
                {
                    // Returning null as a sign that the data was not retrieved.
                    animeList = null;
                }
            }

            // Returning the Anime list.
            return animeList;
        }

        /// <summary>
        /// Returns the Manga list of the given passed username.
        /// </summary>
        /// <param name="username"> The user's name. </param>
        /// <param name="totalEntries"> The total Manga entries of the user. </param>
        /// <param name="ct"> The cancellation token that permits the task's cancellation. </param>
        /// <returns> A list of the user's Manga entries. </returns>
        public async static Task<IEnumerable<MangalistEntryModel>> GetMangaList(string username, int totalEntries, CancellationToken ct)
        {
            // Getting the number of pages of the user's Manga list.
            int pages = (int)Math.Ceiling((decimal)totalEntries / 300);

            // Instaltiating the list that will temporarely hold the retrieved Manga entries.
            List<MangalistEntryModel> mangaList = new List<MangalistEntryModel>();

            // Lopping through the pages of the user's Manga list.
            foreach (int i in Enumerable.Range(1, pages))
            {
                // Setting up the request's URL.
                string url = $"{ client.BaseAddress.AbsoluteUri }user/{ username }/mangalist/all/{ i }";

                // Getting the response asynchronously.
                HttpResponseMessage response = await client.GetAsync(url);

                // Throwing the cancellation check.
                ct.ThrowIfCancellationRequested();

                // Checking if the data was successfully retrieved.
                if (response.IsSuccessStatusCode)
                {
                    // Mapping the JSON data into a MangalistEntryResultsModel object.
                    MangalistEntryResultsModel results = await response.Content.ReadAsAsync <MangalistEntryResultsModel>();
                    
                    // Looping through the Manga entries in the retrieved list.
                    foreach (MangalistEntryModel manga in results.Manga)
                    {
                        // Adding the Manga to the temporary list.
                        mangaList.Add(manga);
                    }
                }
                else
                {
                    // Returning null as a sign that the data was not retrieved.
                    mangaList = null;
                }
            }

            // Returning the Manga list.
            return mangaList;
        }

        #endregion
    }
}
