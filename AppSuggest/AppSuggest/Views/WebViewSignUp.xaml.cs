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
    public partial class WebViewSignUp : ContentPage
    {
        public WebViewSignUp()
        {
            InitializeComponent();
        }
        public WebViewSignUp(string url)
        {
            InitializeComponent();

            webview.Source = url;
        }
    }
}