using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMinUp
{
    public partial class App : Application
    {
        public static long Start;
        public static long End;
        public static Label m_label;

        public App()
        {
            var contentPage = new ContentPage();
            var stackLayout = new StackLayout();
            var label = m_label = new Label();
            var button = new Button();

            contentPage.Content = stackLayout;
            stackLayout.Children.Add(label);
            stackLayout.Children.Add(button);

            stackLayout.HorizontalOptions = LayoutOptions.Center;
            stackLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

            label.Text = "XFMinUp!";
            label.FontSize = 50;

            button.Text = "Show Startup Time";
            button.Clicked += Clicked;

            MainPage = contentPage;
        }

        private void Clicked(object sender, EventArgs e)
        {
            m_label.Text = $"OnResume - OnCreate = {End - Start}ms";
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
