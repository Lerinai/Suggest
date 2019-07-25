using AppSuggest;
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
    public partial class EditProfilPage : ContentPage
    {
        User myUser;
        public EditProfilPage(User user)
        {
            myUser = user;
            InitializeComponent();
            profilName.Text = myUser.LastName;
            profilFirstName.Text = myUser.FirstName;
            imageProfil.Source = myUser.Image;

            InitializeComponent();
        }

        async void ValideEditClicked(object sender, EventArgs e)
        {
            if(profilFirstName.Text != "" && profilName.Text != "" &&/* imageProfil.Source != null &&*/ passWord == passWordVerif)
            {
                myUser.LastName = profilName.Text;
                myUser.FirstName = profilFirstName.Text;
                //myUser.image = imageProfil.Source;
                myUser.Password = passWord.Text;

                //edit le user dans la db

                await Navigation.PushAsync(new HomePage()); 
            }
            else if(passWord != passWordVerif)
            {
                await DisplayAlert("Wrong password", "One of password entry isn't correct", "OK");
            }
            else
            {
                await DisplayAlert("Empty entry", "You need feel all entry before validate", "OK");
            }

        }
    }
}