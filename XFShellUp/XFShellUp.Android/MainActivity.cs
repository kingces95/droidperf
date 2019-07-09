using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Internals;

namespace XFShellUp.Droid
{
    [Activity(Label = "XFShellUp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Profile.Start();

            Profile.FrameBegin("OnResume-OnCreate");

            Profile.FrameBegin("OnCreate");
            {
                Profile.FramePartition("base.OnCreate");
                {
                    TabLayoutResource = Resource.Layout.Tabbar;
                    ToolbarResource = Resource.Layout.Toolbar;

                    base.OnCreate(savedInstanceState);
                }

                Profile.FramePartition("Forms.Init");
                {
                    global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
                    Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                }

                App app;
                Profile.FramePartition("new App()");
                {
                    app = new App();
                }
                Profile.FramePartition("LoadApplication()");
                {
                    LoadApplication(app);
                }
            }
			Profile.FrameEnd(); // OnCreate
        }

        protected override void OnResume()
        {
            base.OnResume();
            Profile.FrameEnd(); // OnResume-OnCreate
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}