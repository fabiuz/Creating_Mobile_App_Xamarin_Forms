using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Greetings
{
    public partial class OpacityBindingCodePage : ContentPage
    {
        public OpacityBindingCodePage()
        {
            Label label = new Label
            {
                Text = "Opacity binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Define o contexto de ligação: alvo é label; origem é Slider;
            label.BindingContext = slider;

            // Liga as propriedades: target é Opacity; source é Value.
            label.SetBinding(Label.OpacityProperty, "Value");

            // Constrói a página.
            Padding = new Thickness(10, 0);

            Content = new StackLayout
            {
                Children = { label, slider }
            };


            InitializeComponent();
        }
    }
}
