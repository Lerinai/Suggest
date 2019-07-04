<<<<<<< HEAD

﻿using AppSuggest.Classes;
=======
>>>>>>> Friend profil navigation
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
            friendList.ItemsSource = myUser.friendList;
        }

        public ProfilPage(User user, User myFriend)
        {
            myUser = user;
            InitializeComponent();
            profilName.Text = myFriend.lastName;
            profilFirstName.Text = myFriend.firstName;
            imageProfil.Source = myFriend.image;
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
<<<<<<< HEAD
=======
        void myFriendClicked(object sender, EventArgs e)
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

>>>>>>> Friend profil navigation
    }
}