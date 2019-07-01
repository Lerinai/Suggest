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
        public IList<Movie> movieList { get; private set; }
        public Research()
        {
            _restService = new RestService();
            InitializeComponent();

            BindingContext = this;
        }

        async void Research_clicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(movieSearchBar.Text))
            {
                GUIList.ItemsSource = await _restService.GetDataAsync(GenerateRequestUri(Constants.TMDBEndPoint));
                BindingContext = this;
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