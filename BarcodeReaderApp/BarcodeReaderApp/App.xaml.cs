using System;
using BarcodeReaderApp.Configuration;
using BarcodeReaderApp.Pages;
using BarcodeReaderApp.Services;
using BarcodeReaderApp.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BarcodeReaderApp
{
	public partial class App : PrismApplication
	{
        public App (IPlatformInitializer platformInitializer = null) : base(platformInitializer) 
		{

		}

        protected override void OnInitialized()
        {
            InitializeComponent();
            var mainPageRoute = new Uri($"/{NavigationConstants.NavigationPage}/{NavigationConstants.BarcodeReaderPage}", UriKind.Absolute);
            NavigationService.NavigateAsync(mainPageRoute);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BarcodeReaderPage, BarcodeReaderViewModel>();
            containerRegistry.RegisterSingleton<IProductService, DummyProductService>();
            containerRegistry.RegisterSingleton<IAlertService, AlertService>();
        }
    }
}
