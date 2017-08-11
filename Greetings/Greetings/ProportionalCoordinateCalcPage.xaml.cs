using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProportionalCoordinateCalcPage : ContentPage
    {
        public ProportionalCoordinateCalcPage()
        {
            InitializeComponent();

            Rectangle[] fractionalRects =
            {
                new Rectangle(0.05, 0.1, 0.9, 0.1),     // parte superior externa.
                new Rectangle(0.05, 0.8, 0.9, 0.1),     // parte inferior externa.
                new Rectangle(0.05, 0.1, 0.05, 0.8),    // lado esquerdo externo.
                new Rectangle(0.9, 0.1, 0.05, 0.8),     // lado direito externo.

                new Rectangle(0.15, 0.3, 0.7, 0.1),     // lado superior interno.
                new Rectangle(0.15, 0.6, 0.7, 0.1),     // lado inferior interno.
                new Rectangle(0.15, 0.3, 0.05, 0.4),    // lado esquerdo interno.
                new Rectangle(0.80, 0.3, 0.05, 0.4),    // lado direito interno.
            };

            foreach(Rectangle fractionalRect in fractionalRects)
            {
                Rectangle layoutBounds = new Rectangle
                {
                    // Cálculos das coordenadas proporcional.
                    X = fractionalRect.X / (1 - fractionalRect.Width),
                    Y = fractionalRect.Y / (1 - fractionalRect.Height),

                    Width = fractionalRect.Width,
                    Height = fractionalRect.Height
                };

                absoluteLayout.Children.Add(
                    new BoxView
                    {
                        Color = Color.Blue
                    },
                    layoutBounds,
                    AbsoluteLayoutFlags.All
                    );
            }
        }

        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;

            // Figura terá uma razão de aspecto de 2:1.
            double height = Math.Min(contentView.Width / 2, contentView.Height);
            absoluteLayout.WidthRequest = 2 * height;
            absoluteLayout.HeightRequest = height;
        }
    }
}
