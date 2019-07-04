using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppSuggest
{
    public class People
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }
    }
}
