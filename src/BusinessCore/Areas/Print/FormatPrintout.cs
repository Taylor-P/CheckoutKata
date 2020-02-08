using System.Collections.Generic;
using System.Text;
using BusinessCore.Areas.Offers.Mappers;
using BusinessCore.Areas.Product.Models;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.Print
{
    public class FormatPrintout : IFormatPrintout
    {
        private readonly IOfferMapper _discountMapper;
        private readonly ILogger<FormatPrintout> _logger;

        public FormatPrintout(IOfferMapper discountMapper, ILogger<FormatPrintout> logger)
        {
            _discountMapper = discountMapper;
            _logger = logger;
        }

        public string PrintAvailableProducts(ICollection<ProductTable> products)
        {

            var line = $"----------------------------------------------------\r\n";

            var display = new StringBuilder(line);
            display.Append($"| Available Products                               |\r\n");
            display.Append(line);
            display.Append($"| Product Name | Product Price | Offers            |\r\n");

            foreach (var product in products)
            {
                display.Append($"| {product.Sku.PadRight(12)} " +
                                     $"| £{product.Price.ToString().PadRight(12)} " +
                                     $"| {_discountMapper.MapOfferText(product).PadRight(17)} |\r\n");
            }

            display.Append(line);
            return display.ToString();
        }

        public string PrintReceipt(ShoppingBasket.Models.ShoppingBasket shoppingBasket)
        {
            if (shoppingBasket == null) return string.Empty;

            var line = $"-------------------------------\r\n";
            var blankline = $"|                             |\r\n";

            var display = new StringBuilder(line);
            display.Append($"| Checkout Kata Receipt       |\r\n");
            display.Append(blankline);
            display.Append(line);
            display.Append($"| Qty x Product Name | Price  |\r\n");
            display.Append(blankline);

            foreach (var item in shoppingBasket.Items)
            {
                display.Append($"| {item.Qty.ToString().PadLeft(3)} x {item.Sku.PadRight(12)} " +
                               $"| £{item.Total().ToString().PadRight(5)} |\r\n");
            }

            display.Append(blankline);
            display.Append(line);

            var multibuyShown = false;

            foreach (var discount in shoppingBasket.Discounts)
            {
                if (!multibuyShown)
                {
                    multibuyShown = true;
                    display.Append($"| Multi-buy Savings           |\r\n");
                    display.Append(blankline);
                }

                display.Append($"| {discount.Sku} {discount.Qty.ToString().PadLeft(3)} x " +
                               $"{discount.OfferText.PadRight(10)} | £{discount.TotalOfferPrice().ToString().PadRight(5)} |\r\n");
            }

            display.Append(line);
            display.Append($"| Total: £{shoppingBasket.TotalCost().ToString().PadRight(19)} |\r\n");
            display.Append(line);

            return display.ToString();
        }
    }
}
