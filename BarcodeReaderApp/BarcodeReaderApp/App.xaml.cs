using BarcodeReaderApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BarcodeReaderApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new BarcodeReaderPage();
		}
	}
}
