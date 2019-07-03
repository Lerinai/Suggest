using AppSuggest.Classes;
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
    public partial class ProfilPage : ContentPage
    {
        User myUser;
        public ProfilPage(User user)
        {
            myUser = user;
            InitializeComponent();
            profilName.Text = myUser.lastName;
            profilFirstName.Text = myUser.firstName;
            imageProfil.Source = myUser.image;
            suggestMovie.ItemsSource = myUser.toDoList;
            suggestMovieDone.ItemsSource = myUser.doneMovie;
        }

        public ProfilPage()
        {
            profilName.Text = "Unknow";
            profilFirstName.Text = "Unknow";
        }

        async void EditClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilPage(myUser));
        }

    }
}