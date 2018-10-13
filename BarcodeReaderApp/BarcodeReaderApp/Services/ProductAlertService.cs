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
            if (navigationPage != null)
            {
                Device.BeginInvokeOnMainThread(async () => await navigationPage.CurrentPage.Navigation.PushPopupAsync(new ProductAlertPage(product)));
            }
        }
    }
}
