using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest.Views
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
            GetPopular();
        }

        async void Research_clicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(movieSearchBar.Text))
            {
                MovieList = await _restService.GetMoviesAsync($"{Constants.MovieResearchEndPoint}?api_key={Constants.Key}&query={movieSearchBar.Text.Replace(' ', '+')}");
                GUIList.ItemsSource = MovieList;
            }
        }

        private async void GetDetails(object sender, ItemTappedEventArgs e)
        {
            Movie movie = e.Item as Movie;
            Task<Movie> CastAndCrewPromise = GetCastAndCrew(movie);
            Task<Movie> TrailerPromise = GetTrailer(movie);
            await CastAndCrewPromise;
            await TrailerPromise;
            await Navigation.PushAsync(new MovieDetails(movie));
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

            movie.Director = (from person in ppl
                               where person.Job == "Director"
                               select person).ToList();

            return movie;
        }

        public async Task<Movie> GetTrailer(Movie movie)
        {
            movie.TrailerPath = await _restService.GetTrailerAsync(movie);
            return movie;
        }

        public async void GetPopular()
        {
            GUIList.ItemsSource = await _restService.GetMoviesAsync($"{Constants.MovieEndPoint}/popular?api_key={Constants.Key}", 1, false);
        }
    }
}