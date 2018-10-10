using System;
using BarcodeReaderApp.Pages;
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
        public App() : base(null)
        {

        }

        public App (IPlatformInitializer platformInitializer = null) : base(platformInitializer) 
		{

		}

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("/NavigationPage/BarcodeReaderPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BarcodeReaderPage, BarcodeReaderViewModel>();
        }
    }
}
