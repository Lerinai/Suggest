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
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }
        private void Home_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        private void Profil_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Profil());
        }
        private void Search_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Research());
        }
        private void Category_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Category());
        }
        private void Setting_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Setting());
        }
        private void About_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About());
        }
    }
}