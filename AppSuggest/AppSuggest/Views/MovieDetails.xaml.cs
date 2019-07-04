using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSuggest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetails : ContentPage
    {
        Movie movie;
        public MovieDetails(Movie m)
        {
            movie = m;
            BindingContext = movie;

            InitializeComponent();
        }
    }
}