using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSuggest.Classes;

namespace AppSuggest.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            Navigation.PopAsync();
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Feed:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;
                    case (int)MenuItemType.Friends:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new Research()));
                        break;

                    /*case (int)MenuItemType.Logout:
                        break;*/
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}