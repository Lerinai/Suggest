
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
            profilName.Text = myUser.LastName;
            profilFirstName.Text = myUser.FirstName;
            imageProfil.Source = myUser.Image;
            suggestMovie.ItemsSource = myUser.toDoList;
            suggestMovieDone.ItemsSource = myUser.doneMovie;
            friendList.ItemsSource = myUser.friendList;
        }

        public ProfilPage(User user, User myFriend)
        {
            myUser = user;
            InitializeComponent();
            profilName.Text = myFriend.LastName;
            profilFirstName.Text = myFriend.FirstName;
            imageProfil.Source = myFriend.Image;
            suggestMovie.ItemsSource = myFriend.toDoList;
            suggestMovieDone.ItemsSource = myFriend.doneMovie;
            friendList.ItemsSource = myFriend.friendList;
            editButton.IsVisible = false;
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
        void MyFriendClicked(object sender, EventArgs e)
        {
            friendList.IsVisible = !friendList.IsVisible;
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ProfilPage
                {
                    BindingContext = e.SelectedItem as User
                }
                                           );
            }
        }
    }
}