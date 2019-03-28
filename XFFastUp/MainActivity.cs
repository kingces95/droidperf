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
using System.Threading;
using Xamarin.Forms.Platform.Android;

namespace XFMinUp.Droid
{
    enum InitType
    {
        Normal,
        Explicit,
        Async,
    }

    [Activity(
        Label = "XFFastUp", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    )]
    public class MainActivity : FormsAppCompatActivity
    {
        InitType Init = InitType.Explicit;

		protected override void OnCreate(Bundle savedInstanceState)
        {
			Profile.Push("ignore");
			Profile.Pop();

			Profile.Push("OnResume-OnCreate");

			Profile.Push("OnCreate");
            {
                Profile.PopPush("base.OnCreate");
                {
                    TabLayoutResource = Resource.Layout.Tabbar;
                    ToolbarResource = Resource.Layout.Toolbar;

                    base.OnCreate(savedInstanceState);
                }
                Profile.PopPush("Forms.Init");
                {
                    App.AppName = "XFFastUp";
                    Forms.SetFlags("FastRenderers_Experimental");

                    switch (Init)
                    {
                        case InitType.Explicit:
                            var activation = new ActivationOptions()
                            {
                                Activity = this,
                                Bundle = savedInstanceState,
                                ResourceAssembly = Assembly.GetExecutingAssembly(),
                                Handlers = Exports.Handlers,
                                EffectScopes = null,
                                Flags = ActivationFlags.NoCss
                            };
                            Forms.Init(activation);
                            break;

                        case InitType.Async:
                            var re = new AutoResetEvent(false);
                            var init = new Thread(() =>
                            {
                                Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());
                                re.Set();
                            });
                            init.Start();
                            re.WaitOne();
                            break;

                        default:
                            Forms.Init(this, savedInstanceState, Assembly.GetExecutingAssembly());
                            break;
                    }
                }

                App app;
                Profile.PopPush("new App()");
                {
                    app = new App();
                }
                Profile.PopPush("LoadApplication()");
                {
                    LoadApplication(app);
                }
            }
			Profile.Pop(); // OnCreate
		}

		protected override void OnResume()
        {
            base.OnResume();
			Profile.Pop(); // OnResume-OnCreate
		}
	}
}