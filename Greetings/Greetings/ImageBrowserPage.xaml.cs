using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageBrowserPage : ContentPage
    {
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }

        WebRequest request;
        ImageList imageList;
        int imageListIndex = 0;

        public ImageBrowserPage()
        {
            InitializeComponent();

            // Obtém a lista de photos de stock.
            Uri uri = new Uri("https://developer.xamarin.com/demo/stock.json");
            request = WebRequest.Create(uri);
            request.BeginGetResponse(WebRequestCallBack, null);
        }

        void WebRequestCallBack(IAsyncResult result)
        {
            Device.BeginInvokeOnMainThread(
                ()=> {
                    try
                    {
                        Stream stream = request.EndGetResponse(result).GetResponseStream();

                        // Deseariliza o Json dentro de uma imageList.
                        var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                        imageList = (ImageList)jsonSerializer.ReadObject(stream);

                        if (imageList.Photos.Count > 0)
                        {
                            FetchPhoto();
                        }
                    }
                    catch (Exception exc)
                    {
                        filenameLabel.Text = exc.Message;
                    }
                });
        }

        void OnPreviousButtonClicked(object sender, EventArgs args)
        {
            imageListIndex--;
            FetchPhoto();
        }

        void OnNextButtonClicked(object sender, EventArgs args)
        {
            imageListIndex++;
            FetchPhoto();
        }

        void FetchPhoto()
        {
            // Prepara a imagem.
            image.Source = null;
            string url = imageList.Photos[imageListIndex];

            // Define o nome do arquivo.
            filenameLabel.Text = url.Substring(url.LastIndexOf('/') + 1);

            // Cria a UriImageSource.
            UriImageSource imageSource = new UriImageSource
            {
                Uri = new Uri(url + "?Width=1080"),
                CacheValidity = TimeSpan.FromDays(3)
            };

            // Define a origem da Imagem.
            image.Source = imageSource;

            // Ativa ou desativa butões.
            prevButton.IsEnabled = imageListIndex > 0;
            nextButton.IsEnabled = imageListIndex < imageList.Photos.Count - 1;
        }

        void OnImagePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "IsLoading")
            {
                activityIndicator.IsRunning = ((Image)sender).IsLoading;
            }
        }
    }
}
