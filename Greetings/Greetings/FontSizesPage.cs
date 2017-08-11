using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class FontSizesPage : ContentPage
    {
        public FontSizesPage()
        {
            BackgroundColor = Color.White;
            StackLayout stackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            // Fazer os valores NamedSize.
            NamedSize[] namedSizes =
            {
                NamedSize.Default, NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large
            };

            foreach (NamedSize namedSize in namedSizes)
            {
                double fontSize = Device.GetNamedSize(namedSize, typeof(Label));

                stackLayout.Children.Add(new Label
                {
                    Text = String.Format("Named size = {0} ({1:F2})", namedSize, fontSize),
                    FontSize = fontSize,
                    TextColor = Color.Black
                });
            }

            // Resoluçõa em unidades por polegada de independente de dispositivos.
            double resolution = 160;

            // Desenha a linha separadora horizontal.
            stackLayout.Children.Add(new BoxView
            {
                Color = Color.Accent,
                HeightRequest = resolution / 80
            });

            // Faz alguns tamanhos de pontos numéricos.
            int[] ptSizes = { 4, 6, 8, 10, 12 };

            foreach(double ptSize in ptSizes)
            {
                double fontSize = resolution * ptSize / 72;

                stackLayout.Children.Add(new Label
                {
                    Text = String.Format("Pont Size = {0} ({1:F2})", ptSize, fontSize),
                    FontSize = fontSize,
                    TextColor = Color.Black
                });
            }

            Content = stackLayout;
            
        }
    }
}
