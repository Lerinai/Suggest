<<<<<<< HEAD
﻿using System;
=======
﻿using AppSuggest.Log;
using System;
>>>>>>> 04078247f2ac5592d8ad737262a103515c814dd1
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
<<<<<<< HEAD
using AppSuggest.Views;
=======
>>>>>>> 04078247f2ac5592d8ad737262a103515c814dd1

namespace AppSuggest.Caroussel
{
    [DesignTimeVisible(false)]

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shared : ContentPage
    {
        public Shared()
        {
            InitializeComponent();
        }
        private void SignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}