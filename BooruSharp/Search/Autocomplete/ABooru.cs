using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BooruSharp.Booru
{
    public abstract partial class ABooru
    {
        /// <summary>
        /// Gets a result of autocomplete options from a tag slice
        /// </summary>
        /// <param name="query">The tag slice to autocomplete</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="Search.FeatureUnavailable"/>
        /// <exception cref="System.Net.Http.HttpRequestException"/>
        public virtual async Task<Search.Autocomplete.SearchResult[]> AutocompleteAsync(string query)
        {
            if (!HasAutocompleteAPI)
                throw new Search.FeatureUnavailable();


            Uri url = _format == UrlFormat.Danbooru
                ? CreateUrl(_autocompleteUrl, SearchArg("name_matches") + query)
                : CreateUrl(_autocompleteUrl, SearchArg("q") + query);

            var array = JsonConvert.DeserializeObject<JArray>(await GetJsonAsync(url));

            return GetAutocompleteResultAsync(array);
        }
    }
}