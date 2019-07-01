using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSuggest
{
    public class MovieData
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Year")]
        public long Year { get; set; }
    }
}
