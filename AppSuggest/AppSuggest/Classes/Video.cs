﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSuggest
{
    public class Video
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
