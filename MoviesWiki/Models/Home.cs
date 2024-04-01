using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesWiki.Models
{
    class Home
    {
        public ObservableCollection<Movie> trending {  get; set; }

        public Home() 
        { 
            InitMovies();
        }

        private void InitMovies()
        {
            trending = new ObservableCollection<Movie> 
            { 
                new Movie {Title = "Inception", Description ="A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", Id = 1, Image ="Inception.jpg", PlatformIcons = ["netflix.jpg"], ReleaseYear ="2010"},
                new Movie {Title = "Cinderella", Id = 2, ReleaseYear = "2015", PlatformIcons=["hbo.jpg"], Image="cinderella.jpg", Description= "When her father unexpectedly dies, young Ella finds herself at the mercy of her cruel stepmother and her scheming stepsisters. Never one to give up hope, Ella's fortunes begin to change after meeting a dashing stranger."},
                new Movie {Title = "No Country for Old Men", Id = 3, ReleaseYear = "2007", PlatformIcons=["hbo.jpg"], Image="no_country_for_old_men.jpg", Description= "Violence and mayhem ensue after a hunter stumbles upon the aftermath of a drug deal gone wrong and over two million dollars in cash near the Rio Grande."}
                
            };

        }
    }
}
