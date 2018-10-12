using System;
using System.Threading.Tasks;
using BarcodeReaderApp.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace BarcodeReaderApp.ViewModels
{
    public class BarcodeReaderViewModel : BindableBase
    {
        IProductService _productService;

        ZXing.Result _scanResult;
        public ZXing.Result ScanResult
        {
            get => _scanResult;
            set => SetProperty(ref _scanResult, value);
        }

        bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        DelegateCommand _onScanResultCommand;
        public DelegateCommand OnScanResultCommand
        {
            get => _onScanResultCommand ?? (_onScanResultCommand = new DelegateCommand(async () => await OnScanResult()));
        }

        public BarcodeReaderViewModel(IProductService productService)
        {
            _productService = productService;
        }

        async Task OnScanResult()
        {
            IsScanning = false;

            try
            {
                var scannedProductId = Convert.ToInt64(ScanResult.Text);
                var product = await _productService.GetProductAsync(scannedProductId);
            }
            catch (Exception)
            {

            }
            finally
            {
                IsScanning = true;
            }
        }
    }
}
