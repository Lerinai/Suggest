using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSuggest
{
    public class Movie
    {
        [JsonProperty("id")]
        public int ID { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; private set; }

        public Movie(int id, string titre, string rd)
        {
            ID = id;
            Title = titre;
            ReleaseDate = rd;
        }
    }
}
