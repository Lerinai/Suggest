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
        private string _releaseDate { get; set; }

        public string ReleaseYear
        {
            get
            {
                try
                {
                    return _releaseDate.Substring(0, 4);
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [JsonProperty("poster_path")]
        private string _posterPath;

        public string PosterURL
        {
            get
            {
                if (_posterPath != null)
                {
                    return $"{Constants.PosterEndPoint}/w500{_posterPath}";
                }
                else
                {
                    return "https://i.imgur.com/VKBcwxH.png";
                }
            }
        }

        [JsonProperty("genre_ids")]
        private List<int> _genres;

        public string Genres
        {
            get
            {
                string str = "";
                try
                {
                    foreach (Genre genre in from genreid in _genres
                                            from genreapi in Genre.Genres
                                            where genreid == genreapi.ID
                                            select genreapi)
                    {
                        str += genre.Name + ", ";
                    }
                    return str.Remove(str.Length - 2);
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        public List<People> ListCast { get;  set; }

        public string StringCast
        {
            get
            {
                string str = "";
                try
                {
                    foreach (People actor in ListCast)
                    {
                        str += $"{actor.Name}, ";
                    }
                    return str.Remove(str.Length - 2);
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        public List<People> _director { private get; set; }
        public string Director
        {
            get
            {
                string str = "";
                try
                {
                    foreach (People director in _director)
                    {
                        str += $"{director.Name}, ";
                    }
                    str = str.Remove(str.Length - 2);
                    return str;
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        public string _trailerPath { private get; set; }

        public string TrailerURL
        {
            get
            {
                if (_trailerPath != "")
                {
                    return Constants.YoutubeEndPoint + _trailerPath;
                }
                else
                {
                    return "n/a";
                }
            }
        }
    }
}
