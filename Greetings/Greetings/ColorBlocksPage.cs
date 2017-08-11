using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class ColorBlocksPage : ContentPage
    {
        public ColorBlocksPage()
        {
            StackLayout stackLayout = new StackLayout
            {
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Vertical
            };

            // Itera através dos campos da estrutura Color.
            foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
            {
                // Salta cores obsoletas.
                if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
                {
                    continue;
                }

                if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorView((Color)info.GetValue(null), info.Name));
                }
            }

            // Itera através das propriedades da estrutura Color.
            foreach (PropertyInfo info in typeof(Color).GetRuntimeProperties())
            {
                MethodInfo methodInfo = info.GetMethod;

                if (methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
                {
                    stackLayout.Children.Add(CreateColorView((Color)info.GetValue(null), info.Name));
                }
            }

            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);

            // Põe o StackLayout em um ScrollView.
            Content = new ScrollView
            {
                BackgroundColor = Color.Red,
                Content = stackLayout,
                Orientation = ScrollOrientation.Vertical
            };
        }

        View CreateColorView(Color color, string name)
        {
            return new Frame
            {
                OutlineColor = Color.Accent,
                Padding = new Thickness(5),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                    {
                    new BoxView
                    {
                        Color = color
                    },
                    new Label
                    {
                        Text = name,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    },
                    new StackLayout
                    {
                        Children =
                    {
                    new Label
                    {
                        Text = String.Format("{0:X2}-{1:X2}-{2:X2}",
                        (int)(255 * color.R),
                        (int)(255 * color.G),
                        (int)(255 * color.B)),
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        IsVisible = color != Color.Default
                    },
                    new Label
                    {
                        Text = String.Format("{0:F2}, {1:F2}, {2:F2}",
                        color.Hue,
                        color.Saturation,
                        color.Luminosity),
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        IsVisible = color != Color.Default
                    }
                },
                HorizontalOptions = LayoutOptions.End
                }
                }
                }
            };
        }
    }
}
