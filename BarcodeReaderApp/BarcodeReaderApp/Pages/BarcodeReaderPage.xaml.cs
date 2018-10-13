using System;
using System.Collections.Generic;
using BarcodeReaderApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeReaderPage : ContentPage
	{
        BarcodeReaderViewModel _viewModel;

		public BarcodeReaderPage ()
		{
            InitializeComponent();
            scannerView.Options.PossibleFormats = new List<ZXing.BarcodeFormat> { ZXing.BarcodeFormat.EAN_8 };
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