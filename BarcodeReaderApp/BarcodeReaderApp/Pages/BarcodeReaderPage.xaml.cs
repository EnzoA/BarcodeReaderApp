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
            scannerOverlay.BindingContext = scannerOverlay;
            var timeSpan = TimeSpan.FromSeconds(3);
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
                _viewModel.OnFlashToggled += ToggleFlashIcon;
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

        void ToggleFlashIcon(bool isFlashOn)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                flashSwitchItem.Icon = isFlashOn ? "light_on.png" : "light_off.png";
            });
        }
    }
}