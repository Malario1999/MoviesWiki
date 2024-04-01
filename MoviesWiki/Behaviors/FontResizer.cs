using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWiki.Behaviors
{
    internal class FontResizer : Behavior<Label>
    {
        protected override void OnAttachedTo(Label bindable)
        {
            bindable.SizeChanged += OnLabelSizeChanged;
            base.OnAttachedTo(bindable);
        }

        void OnLabelSizeChanged(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                return;
            }
            Label label = (Label)sender;
            Border parent = (Border) label.Parent.Parent.Parent;
            double desiredWidth = parent.WidthRequest - 20; // Desired width for the label
            double actualWidth = label.Measure(double.PositiveInfinity, double.PositiveInfinity).Request.Width;

            // Adjust font size while the actual width is greater than the desired width
            while (actualWidth > desiredWidth && label.FontSize > 1)
            {
                label.FontSize -= 1;
                actualWidth = label.Measure(double.PositiveInfinity, double.PositiveInfinity).Request.Width;
            }
        }
    }
}
