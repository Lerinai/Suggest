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
                foreach (int id in _genres)
                {
                    str += id + ", ";
                }
                return str.Remove(str.Length-2);
            }
        }
            

        /*public string Genres {
            get
            {
                string genres = "";
                foreach (int id in _genres)
                {
                    genres += (from genre in Research.Genres
                    where id == genre.ID
                    select genre.Name) + ", ";
                }
                return genres.Substring(0, genres.Length-2); 
            }
            private set { } }*/

        public string PosterURL
        {
            get { return $"{Constants.PosterEndPoint}/w200/{ _posterPath}"; }
            private set { }
        }

    }
}
