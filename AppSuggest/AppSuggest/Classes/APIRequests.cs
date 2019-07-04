﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppSuggest
{
    public class APIMovieResults
    {
        [JsonProperty("results")]
        public List<Movie> ResultsArray { get; set; }

        [JsonProperty("total_pages")]
        public int NbPages { get; set; }
    }

    public class APIGenreResults
    {
        [JsonProperty("genres")]
        public List<Genre> ResultsArray { get; set; }
    }

    public class APICreditResults
    {
        [JsonProperty("cast")]
        public List<People> CastMembers { get; set; }

        [JsonProperty("crew")]
        public List<People> CrewMembers { get; set; }
    }

    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Movie>> GetMoviesAsync(string uri, int i = 1)
        {
            APIMovieResults aPIResult = null;
            List<Movie> movieList = new List<Movie>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri + $"&page={i}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    aPIResult = JsonConvert.DeserializeObject<APIMovieResults>(content);
                    movieList.AddRange(aPIResult.ResultsArray);
                    if (aPIResult.NbPages > i)
                    {
                        movieList.AddRange(await GetMoviesAsync(uri, i + 1));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return movieList;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            APIGenreResults aPIResult = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.GenresEndPoint);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    aPIResult = JsonConvert.DeserializeObject<APIGenreResults>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return aPIResult.ResultsArray;
        }

        public async Task<List<People>> GetPeopleAsync(Movie movie)
        {
            APICreditResults aPIResult = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{Constants.MovieDetailsEndPoint}/{movie.ID}/credits?api_key={Constants.Key}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    aPIResult = JsonConvert.DeserializeObject<APICreditResults>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            aPIResult.CastMembers.AddRange(aPIResult.CrewMembers);
            return aPIResult.CastMembers;
        }
    }
}
