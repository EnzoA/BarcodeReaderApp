using System;
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