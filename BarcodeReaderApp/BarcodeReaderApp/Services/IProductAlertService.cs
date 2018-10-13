using BarcodeReaderApp.Models;
using System.Threading.Tasks;

namespace BarcodeReaderApp.Services
{
    public interface IAlertService
    {
        Task ShowProductAlertAsync(Product product);
    }
}
