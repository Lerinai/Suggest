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
    public partial class SwipePage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<SwipeMenuItem> menuItems;

        public SwipePage()
        {
            menuItems = new List<SwipeMenuItem>
            {
                new SwipeMenuItem {Id = MenuItemType.Feed, Title = "Feed"},
                new SwipeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new SwipeMenuItem {Id = MenuItemType.Friends, Title="Friends" },
                new SwipeMenuItem {Id = MenuItemType.Profile, Title="Profile" },
                new SwipeMenuItem {Id = MenuItemType.Settings, Title="Settings" },
                new SwipeMenuItem {Id = MenuItemType.About, Title="About" },
               // new SwipeMenuItem {Id = MenuItemType.Logout, Title="Log out" },
            };

            InitializeComponent();

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[1];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                Console.WriteLine((int)((SwipeMenuItem)e.SelectedItem).Id);
                await RootPage.NavigateFromMenu((int)((SwipeMenuItem)e.SelectedItem).Id);
            };
        }
    }
}