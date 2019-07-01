using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppSuggest
{
    public class MoviesList
    {
        [JsonProperty("results")]
        public List<Movie> ResultsArray { get; set; }
    }

    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Movie>> GetMovieDataAsync(string uri)
        {
            MoviesList moviesList = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    moviesList = JsonConvert.DeserializeObject<MoviesList>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return moviesList.ResultsArray;
        }
    }

}
