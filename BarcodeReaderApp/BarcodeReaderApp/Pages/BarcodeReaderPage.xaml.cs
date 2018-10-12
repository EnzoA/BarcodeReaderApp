using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeReaderPage : ContentPage
	{
		public BarcodeReaderPage ()
		{
            InitializeComponent();
            scannerOverlay.BindingContext = scannerOverlay;
            TimeSpan ts = new TimeSpan(0, 0, 0, 3, 0);
            Device.StartTimer(ts, () =>
            {
                if (scannerView.IsScanning)
                {
                    scannerView.AutoFocus();
                }
                return true;
            });
        }

        void ScannerViewOnScanResult(ZXing.Result result)
        {
            DisplayAlert(title: "Scan result", message: result.Text, cancel: "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            scannerView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            scannerView.IsScanning = false;
            base.OnDisappearing();
        }
    }
}