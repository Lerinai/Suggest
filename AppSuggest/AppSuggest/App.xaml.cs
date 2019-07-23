using AppSuggest.Caroussel;
using AppSuggest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected async override void OnStart()
        {
            RestService _restService = new RestService();
            Genre.Genres = await _restService.GetGenresAsync(); //Get the list of all genres
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
