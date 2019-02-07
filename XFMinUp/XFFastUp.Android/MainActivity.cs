using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using System.Reflection;
using System.Threading;

namespace XFMinUp.Droid
{
    [Activity(Label = "XFFastUp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			XFMinUp.App.Start = Java.Lang.JavaSystem.CurrentTimeMillis(); // custom
			BaseLine.NoOp();
			XFMinUp.App.End = Java.Lang.JavaSystem.CurrentTimeMillis();

			Profile.Push("ignore");
			Profile.Pop();

			Profile.Push("OnResume-OnCreate");

			Profile.Push("OnCreate");
			Profile.PopPush("base.OnCreate");
			TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

			Profile.PopPush("Forms.Init");
			App.AppName = "XFFastUp";
            Forms.SetFlags("FastRenderers_Experimental");

			Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());

			//var re = new AutoResetEvent(false);
			//var init = new Thread(() => {
			//	Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());
			//	re.Set();
			//});
			//init.Start();
			//re.WaitOne();

			Profile.PopPush("new App()");
			var app = new App();

			Profile.PopPush("LoadApplication()");
			LoadApplication(app);
			Profile.Pop(); // OnCreate
		}

		protected override void OnResume()
        {
            base.OnResume();
			Profile.Pop(); // OnResume-OnCreate
		}
	}
}