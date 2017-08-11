using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class FitToSizeClockPage : ContentPage
	{
		public FitToSizeClockPage ()
		{
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = clockLabel;

            // Manipula o evento SizeChanged para a página.
            SizeChanged += (object sender, EventArgs arg) =>
            {
                // Amplia o tamanho da fonte para a largura da página 
                // baseado em 11 caracteres no string exibido.
                if (this.Width > 0)
                {
                    clockLabel.FontSize = this.Width / 6;
                }
            };

            // Inicia o timer.
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Define a propriedade Text do Label.
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");

                return true;
            });
		}
	}
}
