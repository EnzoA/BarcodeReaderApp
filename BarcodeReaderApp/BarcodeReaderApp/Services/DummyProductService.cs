using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcodeReaderApp.Models;

namespace BarcodeReaderApp.Services
{
    public class DummyProductService : IProductService
    {
        List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Mouse",
                Description = "Mouse económico",
                Price = 50,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Description = "Mouse económico",
                Price = 50,
                CurrencySymbol = "$"
            }
        };

        public async Task<Product> GetProductAsync(long id)
        {
            await Task.Delay(1000);
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
