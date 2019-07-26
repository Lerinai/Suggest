using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSuggest.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Application.Current.MainPage = new MainPage();

=======
            Navigation.PushAsync(new HomePage());
>>>>>>> Avancement SettingPage & Modifs HomePage
        }
    }
}