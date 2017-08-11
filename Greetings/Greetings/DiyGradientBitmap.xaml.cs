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
    public partial class DiyGradientBitmap : ContentPage
    {
        public DiyGradientBitmap()
        {
            InitializeComponent();

            GerarImagem();
        }

        private void GerarImagem()
        {
            int rows = 128;
            int cols = 64;

            BmpMaker bmpMaker = new BmpMaker(cols, rows);
            Random aleatorio = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // bmpMaker.SetPixel(row, col, 2 * row, (128 - col), 2 * (128 - row));
                    bmpMaker.SetPixel(row, col, aleatorio.Next(0, 256), aleatorio.Next(0, 256), aleatorio.Next(0, 256));
                }
            }

            ImageSource imageSource = bmpMaker.Generate();
            image.Source = imageSource;
        }

        private void myButton_Clicked(object sender, EventArgs e)
        {
            GerarImagem();
        }
    }
}
