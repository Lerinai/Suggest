using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;


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

        [JsonProperty("poster_path")]
        private string _posterPath;

        [JsonProperty("genre_ids")]
        private List<int> _genres;

        public string Genres
        {
            get
            {
                string str = "";
                foreach(Genre genre in from genreid in _genres
                                            from genreapi in Genre.Genres
                                            where genreid == genreapi.ID
                                            select genreapi)
                {
                    str += genre.Name + ", ";
                }
                return str.Remove(str.Length-2);
            }
        }

        public string PosterURL
        {
        get { return $"{Constants.PosterEndPoint}/w500/{_posterPath}"; }
        private set { }
        }
    }
}
