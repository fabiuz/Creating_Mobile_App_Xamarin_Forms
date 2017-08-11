using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class GreetingsPage : ContentPage
    {
        public GreetingsPage()
        {
            Content = new Label
            {
                Text = "Greetings, Xamarin.Forms!!!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Yellow,
                TextColor = Color.Blue,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            
            };
            Padding = new Thickness(0, 20, 0, 0);
            Device.OnPlatform(() =>
            {
                Padding = new Thickness(0, 20, 0, 0);
            });
        }
    }
}
