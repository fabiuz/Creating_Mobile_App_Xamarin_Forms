using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class ResourceBitmapCodePage : ContentPage
    {
        public ResourceBitmapCodePage()
        {
            Content = new Image
            {
                Source = ImageSource.FromResource("Greetings.Images.ModernUserInterface256.jpg"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
        }
    }
}
