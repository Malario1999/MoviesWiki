using Microsoft.Extensions.Logging;
using MoviesWiki.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Microsoft.UI.Input;

namespace MoviesWiki.Views

{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            

            BindingContext = new Home();

            List<Movie> fuck = new List<Movie>() { new Movie() { Title="fuckface" } };
            resultsList.ItemsSource = fuck;
            
            
        }

        protected override void OnAppearing()
        {
            searchBar.Text = string.Empty;
            resultsList.ItemsSource = null;
            base.OnAppearing();
            
        }

        private async void TapGestureRecognizer_BorderTapped(object sender, TappedEventArgs e)
        {
            var movie = (sender as Element).BindingContext as Movie;
            await Navigation.PushAsync(new MoviePage(movie));
            

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
          
          SearchBar searchBar = (SearchBar)sender;
          var query = searchBar.Text;
          if (query == "")
            {
                resultsList.ItemsSource = null;
                resultsList.IsVisible = false ;
                return;
            }
            resultsList.ItemsSource = (BindingContext as Home).allMovies.Where(movie => movie.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
          resultsList.IsVisible = true;
                

        }

        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            if (resultsList.ItemsSource != null)
            {
                resultsList.IsVisible = true;
            } else
            {
                resultsList.IsVisible = false;
            }

        }

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            resultsList.IsVisible = false;
        }

        private async void resultsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var movie = (sender as ListView).SelectedItem as Movie;
            await Navigation.PushAsync(new MoviePage(movie));
        }
    }



    public class AutoResizeLabel : Label
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            Element immediateParent = this.Parent;
            while (immediateParent is not Border && immediateParent is not null)
            {
                immediateParent = immediateParent.Parent;
            }
            // Calculate desired width for the label
            double desiredWidth = (immediateParent as Border)?.WidthRequest - 20 ?? 180;
            double actualWidth = this.Measure(double.PositiveInfinity, double.PositiveInfinity).Request.Width;

            // Adjust font size while the actual width is greater than the desired width
            while (actualWidth > desiredWidth && this.FontSize > 1)
            {
                this.FontSize -= 1;
                actualWidth = this.Measure(double.PositiveInfinity, double.PositiveInfinity).Request.Width;
            }
        }
    }



}
