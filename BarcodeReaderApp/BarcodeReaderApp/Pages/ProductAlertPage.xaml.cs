using BarcodeReaderApp.Models;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductAlertPage : PopupPage
	{
		public ProductAlertPage (Product product)
		{
			InitializeComponent ();
		}
	}
}