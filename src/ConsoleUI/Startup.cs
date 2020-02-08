using BusinessCore.Areas.DataImport.Repositories;
using BusinessCore.Areas.DataImport.Services;
using BusinessCore.Areas.Offers.Mappers;
using BusinessCore.Areas.Offers.Repositories;
using BusinessCore.Areas.Print;
using BusinessCore.Areas.Product.Mappers;
using BusinessCore.Areas.Product.Repositories;
using BusinessCore.Areas.Product.Services;
using BusinessCore.Areas.Product.UnitOfWorks;
using BusinessCore.Areas.ShoppingBasket;
using BusinessCore.Areas.ShoppingBasket.Models;
using BusinessCore.Areas.ShoppingBasket.Services;
using ConsoleUI.Areas.Application;
using Infrastructure.Areas.Database;
using Infrastructure.Areas.Repositories;
using Infrastructure.Areas.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleUI
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            //Create the service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            
            //Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //Start Application
            serviceProvider.GetService<IApp>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                })
                .AddDbContext<CheckoutContext>(opt => opt.UseInMemoryDatabase("CheckoutDb"))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductUoW, ProductUoW>()
                .AddTransient<IProductFileRepository, ProductFileRepository>()
                .AddTransient<IOfferRepository, OfferRepository>()
                .AddTransient<IDiscountFileRepository, DiscountFileRepository>()
                .AddTransient<IApp,App>()
                .AddTransient<IFormatPrintout, FormatPrintout>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IScanningService, ScanningService>()
                .AddTransient<IProductMapper, ProductMapper>()
                .AddTransient<IItem, Item>()
                .AddTransient<IDiscount, Discount>()
                .AddTransient<IShoppingBasket, ShoppingBasket>()
                .AddTransient<IOfferMapper, OfferMapper>()
                .AddTransient<IImportData, ImportData>();

        }
    }
}
