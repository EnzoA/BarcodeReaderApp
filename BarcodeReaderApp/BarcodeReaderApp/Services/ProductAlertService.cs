using Acr.UserDialogs;
using BarcodeReaderApp.Models;
using BarcodeReaderApp.Pages;
using Rg.Plugins.Popup.Extensions;
using System;
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

        public void ShowToastMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var toastConfig = new ToastConfig(message);
            toastConfig.Duration = TimeSpan.FromSeconds(4);
            toastConfig.BackgroundColor = Color.White;
            toastConfig.MessageTextColor = Color.FromHex("DB3214");
            toastConfig.Position = ToastPosition.Top;
            toastConfig.Icon = "warning.png";
            Device.BeginInvokeOnMainThread(() =>
            {
                UserDialogs.Instance.Toast(toastConfig);
            });
        }
    }
}
