using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class WebBitmapCodePage : ContentPage
    {
        public WebBitmapCodePage()
        {
            Content = new Image
            {
                Source = "https://developer.xamarin.com/demo/IMG_1415.JPG"
            };
        }
    }
}
