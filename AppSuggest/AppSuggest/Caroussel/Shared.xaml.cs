using AppSuggest.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest.Caroussel
{
    [DesignTimeVisible(false)]

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shared : ContentPage
    {
        public Shared()
        {
            InitializeComponent();
        }
        private void SignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}