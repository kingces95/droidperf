using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internal;
using Xamarin.Forms.Xaml;

namespace XFMinUp
{
    public partial class App : Application
    {
        const long MS = TimeSpan.TicksPerMillisecond;
        const int Extra = 0;

        public static string AppName;

        public App()
        {
            var contentPage = new ContentPage();
            var stackLayout = new StackLayout();
            var label = new Label();
            var button = new Button();

            contentPage.Content = stackLayout;
            stackLayout.Children.Add(label);
            stackLayout.Children.Add(button);

            for (var i = 0; i < Extra; i++)
            {
                stackLayout.Children.Add(new Label() { Text = i.ToString() });
                stackLayout.Children.Add(new Button() { Text = i.ToString() });
            }

            stackLayout.HorizontalOptions = LayoutOptions.Center;
            stackLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

            label.Text = $"{AppName}!";
            label.FontSize = 50;

            button.Text = "Show Startup Time";
            button.Clicked += Clicked;

            MainPage = contentPage;
        }

        private void Clicked(object sender, EventArgs e)
        {
            ((ContentPage)MainPage).LoadProfile();
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
