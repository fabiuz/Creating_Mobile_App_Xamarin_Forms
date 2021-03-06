﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class VariableFormattedTextPage : ContentPage
    {
        public VariableFormattedTextPage()
        {
            Content = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "\u2003There was nothing so "},
                        new Span
                        {
                            Text = "very",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " remarkable in that; nor did Alice think it so"
                        },
                        new Span
                        {
                            Text = "very",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " much out of the way to hear the " +
                            "Rabbit say to itself \u2018h " +
                            "dear! Oh dear! I shall be to late!" +
                            "u2019 (when she thought it over " +
                            "aftwerwards, it ocurred to hear that " +
                            "she ought to have wondered at this, " +
                            "but at the time it all seemed quite " +
                            "natural); but, when the Rabbit actually "
                        },
                        new Span
                        {
                            Text = "took a watch out of its waitscoat-pocket",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = ", and looked at it, and then hurried on, " +
                                    "Alice started to her feet, for it flashed " +
                                    "across her mind that she had never before " +
                                    "seen a rabbit with either a waistcoat-" +
                                    "pocket, or a watch to take out of it, " +
                                    "and, burning with curiosity, she ran " +
                                    "across the field after it, and was just " +
                                    "in time to see it pop down a large " +
                                    "rabbit-hold under the hedge."
                        },





                        new Span
                        {
                            Text = "I "
                        },
                        new Span
                        {
                            Text = "love",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        new Span{ Text = "Xamarins Forms!" }
                    }
                },

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
        }
    }
}
