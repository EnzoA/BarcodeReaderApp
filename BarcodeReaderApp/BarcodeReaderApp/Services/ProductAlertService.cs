using BarcodeReaderApp.Models;
using BarcodeReaderApp.Pages;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeReaderApp.Services
{
    public class AlertService : IAlertService
    {
        public Task ShowProductAlertAsync(Product product)
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            Page currentPage = navigationPage?.CurrentPage;
            if (currentPage != null)
            {
                var tcs = new TaskCompletionSource<object>();
                Task.Factory.StartNew(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await currentPage.Navigation.PushPopupAsync(new ProductAlertPage(product, currentPage, tcs));
                    });
                });

                return tcs.Task;
            }

            return null;
        }
    }
}
