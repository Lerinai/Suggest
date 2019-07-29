using AppSuggest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private void Connected_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            //Device.OpenUri(new System.Uri(url));
            Navigation.PushAsync(new WebViewSignUp(url));
        });


        
        
    }
}