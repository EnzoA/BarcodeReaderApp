using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeReaderPage : ContentPage
	{
		public BarcodeReaderPage ()
		{
			InitializeComponent ();
		}

        void ScannerViewOnScanResult(ZXing.Result result)
        {
            DisplayAlert(title: "Scan result", message: result.Text, cancel: "Ok");
        }
    }
}