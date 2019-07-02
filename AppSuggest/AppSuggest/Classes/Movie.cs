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

        public string ReleaseDate
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
            private set { }
        }

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
<<<<<<< HEAD
=======

        public string PosterURL
        {
        get { return $"{Constants.PosterEndPoint}/w500/{_posterPath}"; }
        private set { }
        }
>>>>>>> 8cde4042f61cfcbcad2ab47ca560629ff9adac9d
    }
}
