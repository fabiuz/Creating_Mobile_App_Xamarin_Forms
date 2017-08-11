using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new Greetings.MainPage();
            // MainPage = new GreetingsPage();
            // MainPage = new VariableFormattedTextPage();
            // MainPage = new NamedFontSizesPage();
            // MainPage = new ColorLoopPage();
            // MainPage = new ReflectedColorsPage();
            // MainPage = new VerticalOptionsDemoPage();
            // MainPage = new FramedTextPage();
            // MainPage = new SizeBoxViewPage();
            // MainPage = new ColorBlocksPage();
            // MainPage = new BlackCatPage();
            // MainPage = new FontSizesPage();
            // MainPage = new EstimatedFontSizePage();
            // MainPage = new ButtonLoggerPage();
            // MainPage = new TwoButtonsPage();
            // MainPage = new ButtonLambdasPage();
            // MainPage = new SimplestKeypadPage();
            // MainPage = new CodePlusXamlPage();
            // MainPage = new ScaryColorList();
            // MainPage = new ParameteredConstructorDemo();
            // MainPage = new FactoryMethodDemoPage();
            // MainPage = new XamlClockPage();
            // MainPage = new ColorViewListPage();
            // MainPage = new XamlKeypadPage();
            // MainPage = new MonkeyTapPage();
            // MainPage = new MonkeyTapPage();
            // MainPage = new WebBitmapCodePage();
            // MainPage = new WebBitmapXaml();
            // MainPage = new ResourceBitmapCodePage();
            // MainPage = new StackedBitmapPage();
            // MainPage = new ImageBrowserPage();
            // MainPage = new BitmapStreamsPage();
            // MainPage = new DiyGradientBitmap();
            // MainPage = new NavigationPage( new ToolbarDemoPage());
            // MainPage = new AbsoluteDemoPage();
            // MainPage = new ChessboardFixedPage();
            // MainPage = new ChessboardDynamic();
            // MainPage = new ChessboardProportional();
            MainPage = new ChessboardXamlPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
