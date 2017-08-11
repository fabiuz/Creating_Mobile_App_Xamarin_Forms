using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackedBitmapPage : ContentPage
    {
        public StackedBitmapPage()
        {
            InitializeComponent();
        }

        void OnImageSizeChanged(object sender, EventArgs args)
        {
            Image image = (Image)sender;
            label.Text = String.Format("Render size = {0:F0} x {1:F1}", image.Width, image.Height);
        }
    }

   
}
