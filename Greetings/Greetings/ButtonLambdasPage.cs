using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class ButtonLambdasPage : ContentPage
    {
        public ButtonLambdasPage()
        {
            // Número pra manipular.
            double number = 1;

            // Cria um rótulo pra exibir.
            Label label = new Label
            {
                Text = number.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Cria um primeiro botão e anexa um maninpulador clicked.
            Button timesButton = new Button
            {
                Text = "Double",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            timesButton.Clicked += (sender, args) =>
            {
                number *= 2;
                label.Text = number.ToString();
            };
            // Cria um segundo botão e anexa manipulador.
            Button divideButton = new Button
            {
                Text = "half",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            divideButton.Clicked += (sender, args) =>
            {
                number /= 2;
                label.Text = number.ToString();
            };

            // Monte a página.
            this.Content = new StackLayout
            {
                Children =
                {
                    label,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            timesButton,
                            divideButton
                        }
                    }
                }
            };
        }
    }
}
