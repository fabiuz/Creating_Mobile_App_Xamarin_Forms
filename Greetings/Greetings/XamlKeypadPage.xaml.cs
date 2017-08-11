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
    public partial class XamlKeypadPage : ContentPage
    {
        App app = Application.Current as App;
        public XamlKeypadPage()
        {
            InitializeComponent();
            // displayLabel.Text = app.DisplayLabelText;
           
           
            backspaceButton.IsEnabled = displayLabel.Text != null && displayLabel.Text.Length > 0;
        }
        void OnDigitButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;
            // app.DisplayLabelText = displayLabel.Text;
        }
        void OnBackspaceButtonClicked(object sender, EventArgs args)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);

            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            // app.DisplayLabelText = displayLabel.Text;
        }
    }
}
