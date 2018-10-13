using BarcodeReaderApp.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductAlertPage : PopupPage
	{
		public ProductAlertPage (Product product, Page parentPage, TaskCompletionSource<object> tcs)
		{
			InitializeComponent ();

            string productName = product?.Name;
            string productDescription = product?.Description;
            string currencySymbol = string.IsNullOrEmpty(product?.CurrencySymbol) ? "$" : product.CurrencySymbol;

            titleLabel.Text = string.IsNullOrEmpty(productName) ? "Nombre no disponible" : productName;
            descriptionLabel.Text = string.IsNullOrEmpty(productDescription) ? "Descripción no disponile" : productDescription;
            priceLabel.Text = product == null ? "Precio no disponible" : $"{currencySymbol}{product.Price}";
            okButton.Clicked += async (object sender, EventArgs e) =>
            {
                await parentPage.Navigation.PopPopupAsync();
                tcs?.SetResult(null);
            };
		}
    }
}