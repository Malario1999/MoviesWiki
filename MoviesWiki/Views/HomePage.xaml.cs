using Microsoft.Extensions.Logging;
using MoviesWiki.Models;
using Microsoft.Maui.Controls;

namespace MoviesWiki.Views

{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new Home();
        }

        private async void TapGestureRecognizer_BorderTapped(object sender, TappedEventArgs e)
        {
            var movie = (sender as Element).BindingContext as Movie;
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
