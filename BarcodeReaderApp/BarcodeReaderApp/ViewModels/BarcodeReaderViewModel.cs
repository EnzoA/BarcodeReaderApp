using Prism.Commands;
using Prism.Mvvm;

namespace BarcodeReaderApp.ViewModels
{
    public class BarcodeReaderViewModel : BindableBase
    {
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
            get => _onScanResultCommand ?? (_onScanResultCommand = new DelegateCommand(OnScanResult));
        }

        public BarcodeReaderViewModel()
        {

        }

        void OnScanResult()
        {

        }
    }
}
