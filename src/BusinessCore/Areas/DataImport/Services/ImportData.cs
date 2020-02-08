using System;
using BusinessCore.Areas.DataImport.Repositories;
using BusinessCore.Areas.Product.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.DataImport.Services
{
    public class ImportData : IImportData
    {
        private readonly IProductUoW _productUoW;
        private readonly IProductFileRepository _productFileRepository;
        private readonly IDiscountFileRepository _discountFileRespository;
        private readonly ILogger<ImportData> _logger;

        public ImportData(IProductUoW productUoW, IProductFileRepository productFileRepository, 
            IDiscountFileRepository discountFileRespository, ILogger<ImportData> logger)
        {
            _productUoW = productUoW;
            _productFileRepository = productFileRepository;
            _discountFileRespository = discountFileRespository;
            _logger = logger;
        }

        public bool Import()
        {
            return ImportProductData() & ImportDiscountFile();
        }

        private bool ImportProductData()
        {
            var productFile = _productFileRepository.ProductFile();

            foreach (var product in productFile)
            {
                var details = product.Split(',',2);

                    if (Double.TryParse(details[1], out var price))
                    {
                        _logger.LogInformation($"Loading Details for Product {details[0]}");
                        _productUoW.ProductRepository.CreateProduct(details[0], price);
                    }

            }

            return _productUoW.Save();
        }

        private bool ImportDiscountFile()
        {
            var discountFile = _discountFileRespository.DiscountFile();

            foreach (var discount in discountFile)
            {
                var details = discount.Split(',', 3);

                    if (Int32.TryParse(details[1], out var qty))
                    if (Double.TryParse(details[2], out var discountamount))
                    {
                        _logger.LogInformation($"Loading product for discount {details[0]}");
                        if (_productUoW.ProductRepository.TryGetProductBySku(details[0], out var product))
                        {
                            _logger.LogInformation($"Creating discount for product {details[0]}");
                            product.Discount =
                                _productUoW.DiscountFileRepository.CreateDiscount(qty, discountamount);

                        }
                    }
            }

            return _productUoW.Save(); 
        }
    }
}
