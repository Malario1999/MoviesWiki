using MoviesWiki.Models;

namespace MoviesWiki.Views

{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new Home();

        }
    }

}
