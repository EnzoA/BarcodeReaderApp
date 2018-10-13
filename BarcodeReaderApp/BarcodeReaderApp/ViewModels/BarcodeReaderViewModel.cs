﻿using System;
using System.Threading.Tasks;
using BarcodeReaderApp.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace BarcodeReaderApp.ViewModels
{
    public class BarcodeReaderViewModel : BindableBase
    {
        IProductService _productService;
        IAlertService _alertService;

        public event Action OnFlashToggled;

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

        bool _isTorchOn;
        public bool IsTorchOn
        {
            get => _isTorchOn;
            set => SetProperty(ref _isTorchOn, value);
        }

        DelegateCommand _onScanResultCommand;
        public DelegateCommand OnScanResultCommand
        {
            get => _onScanResultCommand ?? (_onScanResultCommand = new DelegateCommand(async () => await OnScanResult()));
        }

        DelegateCommand _toggleCameraFlashCommand;
        public DelegateCommand ToggleCameraFlashCommand
        {
            get => _toggleCameraFlashCommand ?? (_toggleCameraFlashCommand = new DelegateCommand(() =>
            {
                IsTorchOn = !IsTorchOn;
                OnFlashToggled?.Invoke();
            }));
        }

        public BarcodeReaderViewModel(IProductService productService, IAlertService alertService)
        {
            _productService = productService;
            _alertService = alertService;
        }

        async Task OnScanResult()
        {
            IsScanning = false;

            try
            {
                var scannedProductId = Convert.ToInt64(ScanResult.Text);
                var product = await _productService.GetProductAsync(scannedProductId);
                if (product != null)
                {
                    await _alertService.ShowProductAlertAsync(product);
                }
                else
                {
                    _alertService.ShowToastMessage("Código desconocido");
                }
            }
            catch (Exception)
            {
                _alertService.ShowToastMessage("Ups... se produjo un error");
            }
            finally
            {
                IsScanning = true;
            }
        }
    }
}
