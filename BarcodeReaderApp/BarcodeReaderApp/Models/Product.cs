namespace BarcodeReaderApp.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CurrencySymbol { get; set; }

        public double Price { get; set; }
    }
}
