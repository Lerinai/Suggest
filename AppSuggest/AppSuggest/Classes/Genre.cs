using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSuggest
{
    public class Genre
    {
        [JsonProperty("id")]
        public int ID { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        /*public async static Task<List<Genre>> GetGenres()
        {
            if (_genres == null)
            {
                RestService _restService = new RestService();
                _genres = await _restService.GetGenresAsync();
            }
            return _genres;
        }*/
    }
}
