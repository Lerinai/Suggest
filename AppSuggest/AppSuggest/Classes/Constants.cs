namespace AppSuggest
{
    public static class Constants
    {
        public static string AppName = "OAuthNativeFlow";

        // OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string iOSClientId = "<insert IOS client ID here>";
        public static string AndroidClientId = "<insert Android client ID here>";

        // These values do not need changing
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string iOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string AndroidRedirectUrl = "<insert Android redirect URL here>:/oauth2redirect";


        //API

        public const string Key = "c907fdd04b2640ac48331e900d1cba52";
        public const string MovieResearchEndPoint = "https://api.themoviedb.org/3/search/movie";
        public const string MovieEndPoint = "https://api.themoviedb.org/3/movie";
        public const string PosterEndPoint = "https://image.tmdb.org/t/p";
        public const string YoutubeEndPoint = "https://youtube.com/watch?v=";
        public const string GenresEndPoint = "https://api.themoviedb.org/3/genre/movie/list?api_key=c907fdd04b2640ac48331e900d1cba52";
    }
}
//https://api.themoviedb.org/3/search/movie?api_key=c907fdd04b2640ac48331e900d1cba52&query=Jack+Reacher endpoint + key + query
//https://image.tmdb.org/t/p/w200/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg endpoint + width + poster_url
//https://api.themoviedb.org/3/movie/550/credits?api_key=c907fdd04b2640ac48331e900d1cba52 enpoint + id + credits?api_key