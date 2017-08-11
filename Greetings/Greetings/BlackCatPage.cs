using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class BlackCatPage : ContentPage
    {
        public BlackCatPage()
        {
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10
            };

            // Obter accesso ao recurso texto.
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            string resource = "Greetings.Texts.TheBlackCat.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool gotTitle = false;
                    string line;

                    // Ler uma linha (que é atualmente um parágrafo).
                    while (null != (line = reader.ReadLine()))
                    {
                        Label label = new Label()
                        {
                            Text = line,

                            // Texto preto para ebooks!
                            TextColor = Color.Black
                        };

                        if (!gotTitle)
                        {
                            // Adiciona o primeiro label (o título) para mainStack.
                            label.HorizontalOptions = LayoutOptions.Center;
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, label);
                            label.FontAttributes = FontAttributes.Bold;
                            mainStack.Children.Add(label);
                            gotTitle = true;
                        }
                        else
                        {
                            // Adiciona rótulos subsequentes ao textStack.
                            textStack.Children.Add(label);
                        }
                    }
                }
            }

            ScrollView scrollView = new ScrollView
            {
                Content = textStack,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5, 0),

            };

            // Adiciona o ScrollView como um secundário de mainStack.
            mainStack.Children.Add(scrollView);

            // Define o conteúdo da página para mainSTack.
            Content = mainStack;

            // Fundo branco para ebooks!
            BackgroundColor = Color.White;

            // Adiciona algum preenchimento IOS para a página.
            Padding = new Thickness(0, Device.OnPlatform(20, 20, 0), 0, 0);

        }
    }
}
