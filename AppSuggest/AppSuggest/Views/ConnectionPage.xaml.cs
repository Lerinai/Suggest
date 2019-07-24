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
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage()
        {
            InitializeComponent();
        }

        async void EnterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage()); // Faire lien pour la page initiale avec les verif etc
        }
    }
}