using BarcodeReaderApp.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeReaderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductAlertPage : PopupPage
	{
		public ProductAlertPage (Product product, Page parentPage)
		{
			InitializeComponent ();
            string productName = product?.Name;
            string productDescription = product?.Description;
            titleLabel.Text = string.IsNullOrEmpty(productName) ? "Nombre no disponible" : productName;
            descriptionLabel.Text = string.IsNullOrEmpty(productDescription) ? "Descripción no disponile" : productDescription;
            okButton.Clicked += async (object sender, EventArgs e) => await parentPage.Navigation.PopPopupAsync();
		}
    }
}