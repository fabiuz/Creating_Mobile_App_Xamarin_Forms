using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class BindingSourceCodePage : ContentPage
    {
        public BindingSourceCodePage()
        {
            Label label = new Label
            {
                Text = "BindingSourceCodePage: Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Define o objeto de Binding com objeto source e a propriedade.
            Binding binding = new Binding
            {
                Source = slider,
                Path = "Value"
            };

            // Liga a propriedade Opacity do rótulo à fonte.
            label.SetBinding(Label.OpacityProperty, binding);

            // Constrói a página.
            Padding = new Thickness(10, 0);

            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}
