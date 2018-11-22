using Newtonsoft.Json;

namespace MAL_Reviewer_API.models.SearchModels
{
    /// <summary>
    /// The information related to a search.
    /// </summary>
    public class SearchModel
    {
        /// <summary>
        /// The list of the results of a search.
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public SearchResultsModel[] Results { get; set; }
    }
}
