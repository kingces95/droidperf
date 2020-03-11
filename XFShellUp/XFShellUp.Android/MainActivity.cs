using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using System.Reflection;
using AToolbar = Android.Support.V7.Widget.Toolbar;
using LP = Android.Views.ViewGroup.LayoutParams;
using System.Threading;
using Android.Support.Design.Widget;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Platform.Android;

namespace XFShellUp.Droid
{
    [Activity(Label = "XFShellUp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        CpuUsage __cpuStart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Profile.Start();
			Profile.FrameBegin("Startup");

            Profile.FramePartition("CpuUsage.Now");
            __cpuStart = CpuUsage.Now;

            Profile.FramePartition("AndroidAnticipator.Initialize");
			//AndroidAnticipator.Initialize(this);

			Profile.FramePartition("OnCreate");
            base.OnCreate(savedInstanceState);

            Profile.FramePartition("Forms.SetFlags");
            Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");

            //Profile.FramePartition("Essentials.Init");
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Profile.FramePartition("Forms.Init");
            var activation = new InitializationOptions()
            {
                Activity = this,
                Bundle = savedInstanceState,
                ResourceAssembly = Assembly.GetExecutingAssembly(),
                Handlers = Exports.Handlers,
                EffectScopes = null,
                Flags = InitializationFlags.DisableCss
            };
            Forms.Init(activation);
            //Forms.Forms.Init(this, savedInstanceState);

            Profile.FrameEnd("Startup");

            Profile.FrameBegin("Create App");
            var app = new App();
            Profile.FrameEnd("Create App");

            Profile.FrameBegin("Render App");
            LoadApplication(app);
        }

        protected override void OnResume()
        {
            base.OnResume();

            AndroidAnticipator.ReportUnused();

			Profile.FramePartition("CpuUsage.Now");
            var cpuNow = CpuUsage.Now;
            Profile.WriteLog("CPU UTIL {0}%", cpuNow - __cpuStart);

            Profile.FrameEnd("Render App");
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}