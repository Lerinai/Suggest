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
                return _releaseDate.Substring(0, 4);
            }
        }

        [JsonProperty("poster_path")]
        private string _posterPath;

        public string PosterURL
        {
            get { return $"{Constants.PosterEndPoint}/w500/{_posterPath}"; }
        }

        [JsonProperty("genre_ids")]
        private List<int> _genres;

        public string Genres
        {
            get
            {
                string str = "";
                foreach (Genre genre in from genreid in _genres
                                        from genreapi in Genre.Genres
                                        where genreid == genreapi.ID
                                        select genreapi)
                {
                    str += genre.Name + ", ";
                }
                return str.Remove(str.Length - 2);
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
                foreach (People actor in ListCast)
                {
                    str += $"{actor.Name} ({actor.Character}), ";
                }
                return str.Remove(str.Length - 2);
            }
        }

        public List<People> _director { private get; set; }
        public string Director
        {
            get
            {
                string str = "";
                foreach (People director in _director)
                {
                    str += $"{director.Name}, ";
                }
                return str.Remove(str.Length - 2);
            }
        }

        public string _trailerPath { private get; set; }

        public string TrailerURL
        {
            get
            {
                return Constants.YoutubeEndPoint + _trailerPath;
            }
        }
    }
}
