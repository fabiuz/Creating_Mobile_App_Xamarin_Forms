using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class TwoButtonsPage : ContentPage
    {
        Button addButton, removeButton;
        StackLayout loggerLayout = new StackLayout();

        public TwoButtonsPage()
        {
            // Cria as views do Botão e anexa os manipuladores Clicked.
            addButton = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            addButton.Clicked += OnButtonClicked;

            removeButton = new Button
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false

            };
            removeButton.Clicked += OnButtonClicked;

            this.Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

            // Monta a página.
            this.Content = new StackLayout
            {
                Children = 
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            addButton,
                            removeButton
                        }
                    },
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            if(button == addButton)
            {
                // Adiciona o rótulo ao StackLayout rolável.
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + DateTime.Now.ToString("T")
                });
            }
            else
            {
                // Remove rótulo topmost do StackLayout.
                loggerLayout.Children.RemoveAt(0);
            }

            // Ativa botão "Remove" somente se secundário está presente.
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
    }
}
