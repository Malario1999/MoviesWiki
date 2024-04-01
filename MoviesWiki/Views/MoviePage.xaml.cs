using MoviesWiki.Models;

namespace MoviesWiki.Views
{
    public partial class MoviePage : ContentPage
    {
        public MoviePage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;
        }
    }
}
