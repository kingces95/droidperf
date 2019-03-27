using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFShellUp.Views
{
    public partial class AboutPage : ContentPage
    {
        public static AboutPage Singleton; 

        public AboutPage()
        {
            Singleton = this;
            InitializeComponent();
        }
    }
}