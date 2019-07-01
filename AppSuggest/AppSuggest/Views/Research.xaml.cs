using System;
using System.Collections.Generic;
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
        List<Movie> movieList;
        public Research()
        {
            movieList = new List<Movie>();
            _restService = new RestService();
            InitializeComponent();

            BindingContext = this;
        }

        async void Research_clicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(movieSearchBar.Text))
            { 
                movieList = await _restService.GetMovieDataAsync(GenerateRequestUri(Constants.TMDBEndPoint));
            }
        }
        
        string GenerateRequestUri(string endpoint)
        {
            string requestURL = endpoint;
            requestURL += $"?api_key={Constants.TMDBKey}";
            requestURL += $"&query={movieSearchBar.Text.Replace(' ', '+')}";
            return requestURL;
        }

    }
}