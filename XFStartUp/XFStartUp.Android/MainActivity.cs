using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Internal;
using System.Reflection;

namespace XFStartUp.Droid
{
	[Activity(Label = "XFStartUp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			XFStartUp.MainPage.Start = Java.Lang.JavaSystem.CurrentTimeMillis();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			// Change XF template to use Assembly.GetExecutingAssembly()
			Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());
			LoadApplication(new App());
		}

		protected override void OnResume()
		{
			base.OnResume();
			XFStartUp.MainPage.End = Java.Lang.JavaSystem.CurrentTimeMillis();
		}
	}
}