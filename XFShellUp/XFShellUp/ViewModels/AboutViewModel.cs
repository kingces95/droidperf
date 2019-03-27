using System;
using System.Windows.Input;

using Xamarin.Forms;
using XFShellUp.Views;

namespace XFShellUp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => {
                AboutPage.Singleton.LoadProfile();
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}