﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BarcodeReaderApp.Droid
{
    [Activity(Label = "Barcode Reader", Icon = "@mipmap/barcode_scanner", Theme = "@style/MainTheme",
              MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#425156"));
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Acr.UserDialogs.UserDialogs.Init(this);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

