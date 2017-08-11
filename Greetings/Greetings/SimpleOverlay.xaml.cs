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
    public partial class SimpleOverlay : ContentPage
    {
        public SimpleOverlay()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            // Exibe um overlay com ProgressBar.
            overlay.IsVisible = true;

            TimeSpan duration = TimeSpan.FromSeconds(5);
            DateTime startTime = DateTime.Now;

            // Inicia o timer.
            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                double progress = (DateTime.Now - startTime).TotalMilliseconds / duration.TotalMilliseconds;
                progressBar.Progress = progress;
                bool continueTimer = progress < 1;

                if (!continueTimer)
                {
                    // Ocultar overlay.
                    overlay.IsVisible = false;
                }
                return continueTimer;
            });
        }
    }
}
