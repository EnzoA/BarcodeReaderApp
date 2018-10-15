using BarcodeReaderApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeReaderPage : ContentPage
	{
        BarcodeReaderViewModel _viewModel;

		public BarcodeReaderPage ()
		{
            InitializeComponent();
            scannerView.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.EAN_8, BarcodeFormat.EAN_13 };
            scannerOverlay.BindingContext = scannerOverlay;
            var timeSpan = new TimeSpan(0, 0, 0, 3, 0);
            Device.StartTimer(timeSpan, () =>
            {
                if (scannerView.IsScanning)
                {
                    scannerView.AutoFocus();
                }
                return true;
            });
        }
        
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _viewModel = BindingContext as BarcodeReaderViewModel;
            if (_viewModel != null)
            {
                _viewModel.OnFlashToggled += () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        flashSwitchItem.Icon = _viewModel.IsTorchOn ? "light_on.png" : "light_off.png";
                    });
                };
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel != null)
            {
                _viewModel.IsScanning = true;
            }
        }

        protected override void OnDisappearing()
        {
            if (_viewModel != null)
            {
                _viewModel.IsScanning = false;
            }
            base.OnDisappearing();
        }
    }
}