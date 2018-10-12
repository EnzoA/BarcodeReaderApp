using System.Collections.Generic;
using System.Threading.Tasks;
using BarcodeReaderApp.Models;

namespace BarcodeReaderApp.Services
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(long id);
    }
}
