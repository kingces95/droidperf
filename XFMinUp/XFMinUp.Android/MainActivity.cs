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

namespace XFMinUp.Droid
{
	[Activity(Label = "XFMinUp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			XFMinUp.App.Start = Java.Lang.JavaSystem.CurrentTimeMillis();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Profile.Push("OnCreate");
			App.AppName = "XFMinUp";
			// Change XF template to use Assembly.GetExecutingAssembly()
			Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());
			LoadApplication(new App());
			Profile.Pop();
		}

		protected override void OnResume()
		{
			base.OnResume();
			XFMinUp.App.End = Java.Lang.JavaSystem.CurrentTimeMillis();
		}
	}
}