using AppSuggest.Views.FolderSetting;
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
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();
        }
        private void GeneralButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new General());
        }
        private void AccountButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Account());
        }
        private void ConfidentialityButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Confidentiality());
        }

    }
}