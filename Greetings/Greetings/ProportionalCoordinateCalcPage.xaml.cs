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
                new Rectangle(0.5, 0.1, 0.9, 0.1),
                new Rectangle(0.5, 0.8, 0.9, 0.1),
                new Rectangle(0.5, 0.1, 0.5, 0.8),
                new Rectangle(0.9, 0.1, 0.5, 0.8),

                new Rectangle(0.15, 0.3, 0.7, 0.1),
                new Rectangle(0.15, 0.6, 0.7, 0.1),
                new Rectangle(0.15, 0.3, 0.05, 0.4),
                new Rectangle(0.15, 0.3, 0.05, 0.4),
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

        }
    }
}
