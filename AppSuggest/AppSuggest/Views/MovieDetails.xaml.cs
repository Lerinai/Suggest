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
        RestService _restService;
        Movie movie;
        public MovieDetails(Movie m)
        {
            movie = m;
            GetCastAndCrew(_restService.GetPeopleAsync(movie).Result);
           

            InitializeComponent();
        }

        public void GetCastAndCrew(List<People> ppl)
        {
            movie.ListCast = (from person in ppl
                           where person.Character != null
                           select person).ToList(); ;
            movie.ListCast.RemoveRange(3, movie.ListCast.Count - 3);

            movie._director = (from person in ppl
                             where person.Job == "Director"
                             select person).ToList();
        }
    }
}