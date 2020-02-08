using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.ShoppingBasket.Models;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.Offers.Mappers
{
    public class OfferMapper : IOfferMapper
    {
        private readonly ILogger<OfferMapper> _logger;

        public OfferMapper(ILogger<OfferMapper> logger)
        {
            _logger = logger;
        }

        public Discount MapToDiscount(ProductTable productTable)
        {
            if (productTable.Discount == null) return null;

            return new Discount
            {
                Sku = productTable.Sku,
                OfferText = MapOfferText(productTable),
                PricePerOffer = productTable.Discount.DiscountedAmount,
                Qty = 0

            };
        }

        public string MapOfferText(ProductTable productTable)
        {
            if (productTable.Discount == null) return string.Empty;

            return $"{productTable.Discount?.NumberOfItems} for £" +
                   $"{(productTable.Discount?.NumberOfItems * productTable.Price) + productTable.Discount?.DiscountedAmount}";

        }
    }
}
