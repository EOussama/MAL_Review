using System;
using System.Net.Http;
using System.Net.Http.Headers;
using MAL_Reviewer_API.models;
using System.Threading.Tasks;

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
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.jikan.moe/v3/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Responsible on searching for results that have to do with the passed arguments and returning them back.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <returns> Task<SearchModel> </returns>
        public async static Task<SearchModel> Search(string type, string title)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }search/{ type }?q={ title }&page=1&limit=10";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchModel>();
            }

            return null;
        }

        /// <summary>
        /// Retrieve the anime of the matching id.
        /// </summary>
        /// <param name="animeId"></param>
        /// <returns></returns>
        public async static Task<AnimeModel> GetAnime(int animeId)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }anime/{ animeId }";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<AnimeModel>();
            }

            return null;
        }

        /// <summary>
        /// Retrieve the manga of the matching id.
        /// </summary>
        /// <param name="mangaId"></param>
        /// <returns></returns>
        public async static Task<MangaModel> GetManga(int mangaId)
        {
            string url = $"{ client.BaseAddress.AbsoluteUri }manga/{ mangaId }";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<MangaModel>();
            }

            return null;
        }
    }
}
