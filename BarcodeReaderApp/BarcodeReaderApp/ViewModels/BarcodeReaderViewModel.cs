using System;
using Prism.Commands;
using Prism.Mvvm;

namespace BarcodeReaderApp.ViewModels
{
    public class BarcodeReaderViewModel : BindableBase
    {
        ZXing.Result scanResult;
        public ZXing.Result ScanResult
        {
            get => scanResult;
            set => SetProperty(ref scanResult, value);
        }

        DelegateCommand onScanResultCommand;
        public DelegateCommand OnScanResultCommand
        {
            get => onScanResultCommand ?? (onScanResultCommand = new DelegateCommand(OnScanResult));
        }

        void OnScanResult()
        {

        }
    }
}
