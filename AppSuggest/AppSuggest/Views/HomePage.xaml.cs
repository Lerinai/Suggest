using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RestService _restService;
        List<Movie> popMovies;
        public HomePage()
        {
            _restService = new RestService();
            GetPopular();
            InitializeComponent();
        }
        public async void GetPopular()
        {
            popMovies = await _restService.GetMoviesAsync($"{Constants.MovieEndPoint}/popular?api_key={Constants.Key}", 1, false);
            
        }
        private void Setting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Setting());
        }
        
    }
}