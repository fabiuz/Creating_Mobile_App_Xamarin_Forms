using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BitmapStreamsPage : ContentPage
    {
        public BitmapStreamsPage()
        {
            InitializeComponent();

            // Carrega bitmap de recurso incorporado.
            string resourceID = "Greetings.Images.ModernUserInterface256.jpg";
            image1.Source = ImageSource.FromStream(
                () =>
                {
                    Assembly assembly = GetType().GetTypeInfo().Assembly;
                    Stream stream = assembly.GetManifestResourceStream(resourceID);
                    return stream;
                });

            Uri uri = new Uri("https://developer.xamarin.com/demo/IMG_0925.JPG?width=512");
            WebRequest request = WebRequest.Create(uri);
            request.BeginGetResponse((IAsyncResult arg) =>
            {
                Stream stream = request.EndGetResponse(arg).GetResponseStream();

                if(Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    MemoryStream memStream = new MemoryStream();
                    stream.CopyTo(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                    stream = memStream;
                }
                ImageSource imageSource = ImageSource.FromStream(() => stream);
                Device.BeginInvokeOnMainThread(() => image2.Source = imageSource);
            }, null);
        }
    }
}
