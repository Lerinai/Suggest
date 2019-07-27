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
    public class Option
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }
    public partial class General : ContentPage
    {
        //List<Option> options();
        public General()
        {
            InitializeComponent();
            //options = new List<Option>();
            //options.Add(new Option { Name = "Lait", Description = "Deux briques de lait" });
            //options.Add(new Option { Name = "Canne à sucre", Description = "100% locale" });
            //options.Add(new Option { Name = "Rhum-Vieux",  Description = "En tout honneur" });
            //options.Add(new Option { Name = "Abricot", Description = "Pêché mignon" });

            //GeneralOptions.ItemsSource = options;
            //GeneralOptions.ItemSelected += (sender, e) =>
            //{
            //    if (GeneralOptions.SelectedItem != null)
            //    {

            //        Option item = GeneralOptions.SelectedItem as Option;

            //        DisplayAlert(item.Name, item.Description, "OK");
            //        GeneralOptions.SelectedItem = null;
            //    }

            }

        }
    }
