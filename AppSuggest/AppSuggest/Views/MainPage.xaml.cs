using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppSuggest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string ClientID = "457784411675175";
        public string accessToken;
        public MainPage()
        {
            InitializeComponent();

            var apiRequest = "https://www.facebook.com/v3.3/dialog/oauth?client_id=" + ClientID + "&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            accessToken = ExtractAccessTokenFromUrl(e.Url);

            if(accessToken != "")
            {
                await GetFacebookProfileAsync(accessToken);
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            string extractedToken = "";
            if (url.Contains("access_token") && url.Contains("&expires_in"))
            {
                extractedToken = url.Replace("https://www.facebook.com/connect/login_success.html#access_token", "");
                extractedToken = extractedToken.Replace("&expires_in", "");
            }
            return extractedToken;
        }

            public async Task GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.7/me" + "?fields=name,picture,age_range,cover,devices,is_verified" + "&access_token=" + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);
        }
    }
}
