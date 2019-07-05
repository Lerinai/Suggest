using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Research : ContentPage
    {
        RestService _restService;
        public IList<Movie> MovieList { get; private set; }
        public Research()
        {
            _restService = new RestService();
            InitializeComponent();

            BindingContext = this;
        }

        async void Research_clicked(object sender, EventArgs args)
        {
            /*if (Genre.Genres == null)
            {
                Genre.Genres = await _restService.GetGenresAsync();
            }*/
            if (!string.IsNullOrWhiteSpace(movieSearchBar.Text))
            {
                MovieList = await _restService.GetMoviesAsync(GenerateRequestUri(Constants.MovieResearchEndPoint));
                GUIList.ItemsSource = MovieList;
                BindingContext = this;
            }
        }
        
        string GenerateRequestUri(string endpoint)
        {
            string requestURL = endpoint;
            requestURL += $"?api_key={Constants.Key}";
            requestURL += $"&query={movieSearchBar.Text.Replace(' ', '+')}";
            return requestURL;
        }

        private async void GetDetails(object sender, ItemTappedEventArgs e)
        {
            Movie movie = e.Item as Movie;
            Task<Movie> CastAndCrewPromise = GetCastAndCrew(movie);
            Task<Movie> TrailerPromise = GetTrailer(movie);
            await CastAndCrewPromise;
            await TrailerPromise;
            Navigation.PushAsync(new MovieDetails(movie));
        }

        public async Task<Movie> GetCastAndCrew(Movie movie)
        {
            List<People> ppl = await _restService.GetPeopleAsync(movie);

            movie.ListCast = (from person in ppl
                              where person.Character != null
                              select person).ToList();
            try
            {
                movie.ListCast.RemoveRange(3, movie.ListCast.Count - 3);
            } catch { }

            movie._director = (from person in ppl
                               where person.Job == "Director"
                               select person).ToList();

            return movie;
        }

        public async Task<Movie> GetTrailer(Movie movie)
        {
            movie._trailerPath = await _restService.GetTrailerAsync(movie);
            return movie;
        }
    }
}