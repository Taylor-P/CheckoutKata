using System;
using BusinessCore.Areas.DataImport.Services;
using BusinessCore.Areas.Print;
using BusinessCore.Areas.Product.Services;
using BusinessCore.Areas.ShoppingBasket.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleUI.Areas.Application
{
    public class App : IApp
    {
        private readonly ILogger<App> _logger;
        private readonly IServiceProvider _serviceProvider;

        public App(ILogger<App> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {

            var input = string.Empty;

            _logger.LogInformation("Application Loading");
            
            _serviceProvider.GetService<IImportData>().Import();

            Console.Clear();

            WriteProducts();

            Console.WriteLine("Scan in product or press F2 to enter product management");

            do
            {
                var key = Console.ReadKey();

                if (key.Key.ToString() == "F2")
                {
                    ProductManagement();
                }
                else
                {
                    input = input + key.Key + ",";
                }
                
                Console.Clear();
                WriteReceipt(input);
                WriteProducts();
                Console.WriteLine("Scan in another product or press F2 to enter product management");
            } while (true);
            
        }

        private void ProductManagement()
        {
            var offer = 0;
            double discountPrice = 0;

            Console.Clear();
            Console.WriteLine("Do you want to create a new Product? (Y/N)");

            if (!Console.ReadKey().Key.ToString().ToUpper().Equals("Y"))
                return;

            Console.WriteLine();

            var sku = GetSku();

            var price = GetProductPrice();

            Console.WriteLine();
            Console.WriteLine("Do you want to add an Offer for your new Product? (Y/N)");
            if (Console.ReadKey().Key.ToString().ToUpper().Equals("Y"))
            {
                offer = GetOffer();

                discountPrice = GetDiscountAmount();
            }

            _serviceProvider.GetService<IProductService>().CreateNewProduct(sku, price, offer, discountPrice);
        }

        private string GetSku()
        {
            Console.WriteLine("Enter new Products SKU (Only Single Character)");
            return Console.ReadKey().Key.ToString().ToUpper();
        }

        private double GetDiscountAmount()
        {
            var discountPrice = 0.0D;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter new Offer discount amount (In £s)");
                if (double.TryParse(Console.ReadLine(), out var discountPriceOut))
                {
                    discountPrice = discountPriceOut;
                }
                else
                {
                    Console.WriteLine("Price MUST be numeric");
                }
            } while (discountPrice <= 0);

            return discountPrice;
        }

        private int GetOffer()
        {
            var offer = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the amount of Products that must be brought for the Offer to apply");
                if (int.TryParse(Console.ReadLine(), out var offerOut))
                {
                    offer = offerOut;
                }
                else
                {
                    Console.WriteLine("You MUST enter a numeric value");
                }
            } while (offer <= 0);

            return offer;
        }

        private double GetProductPrice()
        {
            var price = 0.0D;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter new Products price (In £s)");
                if (double.TryParse(Console.ReadLine(), out var priceOut))
                {
                    price = priceOut;
                }
                else
                {
                    Console.WriteLine("Price MUST be numeric");
                }
            } while (price <= 0);

            return price;
        }

        private void WriteReceipt(string scannedList)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(_serviceProvider.GetService<IFormatPrintout>()
                .PrintReceipt(
                _serviceProvider.GetService<IScanningService>()
                    .Scan(scannedList)));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        } 

        private void WriteProducts()
        {          

            Console.WriteLine(_serviceProvider.GetService<IFormatPrintout>()
                .PrintAvailableProducts(
                    _serviceProvider.GetService<IProductService>()
                        .GetListOfAvailableProducts()));
        }
    }
}
