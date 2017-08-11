using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Greetings
{
    public partial class ColorView : ContentView
    {
        string colorName;
        ColorTypeConverter colorTypeConv = new ColorTypeConverter();
        
        public ColorView()
        {
            InitializeComponent();
        }

        public string ColorName
        {
            set
            {
                // Define o nome.
                colorName = value;
                colorNameLabel.Text = value;

                // Obtém a cor atual e define outras visualizações.
                Color color = (Color)colorTypeConv.ConvertFromInvariantString(colorName);
                boxView.Color = color;
                colorValueLabel.Text = String.Format("{0:X2}-{1:X2}-{2:X2}",
                    (int)(255 * color.R),
                    (int)(255 * color.G),
                    (int)(255 * color.B));
            }
            get
            {
                return colorName;
            }
        }
    }
}
