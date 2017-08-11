using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Reflection;

using Xamarin.Forms;

namespace Greetings
{
    public class ReflectedColorsPage : ContentPage
    {
        public ReflectedColorsPage()
        {
            StackLayout stackLayout = new StackLayout
            {
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal
            };

            // Itera através dos campos da estrutura Color.
            foreach(FieldInfo info in typeof(Color).GetRuntimeFields())
            {
                // Salta cores obsoletas.
                if(info.GetCustomAttribute<ObsoleteAttribute>() != null)
                {
                    continue;
                }

                if(info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            // Itera através das propriedades da estrutura Color.
            foreach(PropertyInfo info in typeof(Color).GetRuntimeProperties())
            {
                MethodInfo methodInfo = info.GetMethod;

                if(methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(null), info.Name));
                }
            }

            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);

            // Põe o StackLayout em um ScrollView.
            Content = new ScrollView
            {
                BackgroundColor = Color.Red,
                Content = stackLayout,
                Orientation = ScrollOrientation.Horizontal
            };
        }

        Label CreateColorLabel(Color color, string name)
        {
            Color backgroundColor = Color.Default;

            if(color != Color.Default)
            {
                // Cálculo da luminancia padrão.
                double luminance = 0.30 * color.R +
                    0.59 * color.G +
                    0.11 * color.B;

                backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
            }

            // Cria um rótulo.
            return new Label
            {
                Text = name,
                TextColor = color,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                BackgroundColor = backgroundColor,
                // HorizontalOptions = LayoutOptions.Start
            };
        }


    }
}
