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
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage()
        {
            InitializeComponent();
        }

        async void EnterClicked(object sender, EventArgs e)
        {
            //try
            //{
            //    List<User> connectionUser = from user in 
            //                          where user.email == email.Text && user.password == password.Text
            //                          select user;
            //    if(connectionUser.Count == 1)
            //    {
            //        await Navigation.PushAsync(new MainPage());
            //    }
            //    else
            //    {
            //        await DisplayAlert("Connection failed", "Password or email invalid try again or create account", "OK");
            //    }
            //}
            //catch
            //{

            //}
            await Navigation.PushAsync(new MainPage());
        }
    }
}