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
                Name = "Mouse Logitech",
                Description = "Mouse óptico",
                Price = 50,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 2,
                Name = "Teclado Genius",
                Description = "Versátil teclado multifunción",
                Price = 150,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 3,
                Name = "MacBook Pro",
                Description = null,
                Price = 3000,
                CurrencySymbol = "USD"
            },
            new Product
            {
                Id = 4,
                Name = "Monitor Samsung 22",
                Description = "Ultra Slim Full HD 1080",
                Price = 6999,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 5,
                Name = "Repetidor WiFi Tp-Link",
                Description = string.Empty,
                Price = 1400,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 6,
                Name = "Alexa Echo (2nd Generation)",
                Description = "Dolby powered smart speaker with Alexa",
                Price = 120,
                CurrencySymbol = "USD"
            },
            new Product
            {
                Id = 1234565,
                Name = "Google Chromecast 2",
                Description = "Reproduce contenido multimeadia en streaming desde un dispositivo móvil",
                Price = 2700,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 8,
                Name = "Google Chromecast 2",
                Description = "Reproduce contenido multimeadia en streaming desde un dispositivo móvil",
                Price = 2700,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 9,
                Name = "Dahua NVR724DR",
                Description = "NVR 256Ch 24HDD RAID iSCSI SAS Hot-Swap",
                Price = 209999,
                CurrencySymbol = "$"
            },
            new Product
            {
                Id = 10,
                Name = "Cargador inalámbrico Qi",
                Description = "Basa para carga inalámbrica de smartphone con standard Qi",
                Price = 997,
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
