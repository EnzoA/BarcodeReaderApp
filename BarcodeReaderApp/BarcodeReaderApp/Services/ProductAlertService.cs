using BarcodeReaderApp.Models;
using BarcodeReaderApp.Pages;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace BarcodeReaderApp.Services
{
    public class AlertService : IAlertService
    {
        public void ShowProductAlert(Product product)
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            Page currentPage = navigationPage?.CurrentPage;
            if (currentPage != null)
            {
                Device.BeginInvokeOnMainThread(async () => await currentPage.Navigation.PushPopupAsync(new ProductAlertPage(product, currentPage)));
            }
        }
    }
}
