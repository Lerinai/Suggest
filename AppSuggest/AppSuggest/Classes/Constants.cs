using System;
using System.Collections.Generic;
using System.Text;

namespace AppSuggest
{
    public class Constants
    {
        public const string MovieResearchEndPoint = "https://api.themoviedb.org/3/search/movie";
        public const string GenresEndPoint = "https://api.themoviedb.org/3/genre/movie/list?api_key=c907fdd04b2640ac48331e900d1cba52";
        public const string Key = "c907fdd04b2640ac48331e900d1cba52";
        public const string PosterEndPoint = "https://image.tmdb.org/t/p";
    }
}
//https://api.themoviedb.org/3/search/movie?api_key=c907fdd04b2640ac48331e900d1cba52&query=Jack+Reacher
//https://image.tmdb.org/t/p/w200/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg endpoint + width + poster_url