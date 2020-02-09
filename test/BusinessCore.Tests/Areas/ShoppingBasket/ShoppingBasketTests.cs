using System.Collections.Generic;
using BusinessCore.Areas.ShoppingBasket.Models;
using FluentAssertions;
using Xunit;

namespace BusinessCore.Tests.Areas.ShoppingBasket
{
    public class ShoppingBasketTests
    {
        private IShoppingBasket _sut;

        [Theory]
        [InlineData(10,5,5,2,60)]
        [InlineData(100,5,5,2,510)]
        [InlineData(9,1,9,9,90)]
        public void TotalItemCost_Success(double itemOnePrice, double itemTwoPrice, int itemOneQty, int itemTwoQty, double expectedResult)
        {
            //Arrange
            _sut = new BusinessCore.Areas.ShoppingBasket.Models.ShoppingBasket
            {
                Items = new List<IItem>
                {
                    new Item{PricePerItem = itemOnePrice,Qty = itemOneQty},
                    new Item{PricePerItem = itemTwoPrice,Qty = itemTwoQty}
                }
            };

            //Act
            var result = _sut.TotalItemsCost();

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(10,5,5,2,60)]
        [InlineData(100,5,5,2,510)]
        [InlineData(9,1,9,9,90)]
        public void TotalDiscountCost_Success(double discountOnePrice, double discountTwoPrice, int discountOneQty, int discountTwoQty, double expectedResult)
        {
            //Arrange
            _sut = new BusinessCore.Areas.ShoppingBasket.Models.ShoppingBasket
            {
                Discounts = new List<IDiscount>
                {
                    new Discount{PricePerOffer = discountOnePrice,Qty = discountOneQty},
                    new Discount{PricePerOffer = discountTwoPrice,Qty = discountTwoQty}
                }
            };

            //Act
            var result = _sut.TotalDiscountCost();

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(10,5,5,2,60)]
        [InlineData(100,5,5,2,510)]
        [InlineData(9,1,9,9,90)]
        public void TotalCost_NoDiscount(double itemOnePrice, double itemTwoPrice, int itemOneQty, int itemTwoQty, double expectedResult)
        {
            //Arrange
            _sut = new BusinessCore.Areas.ShoppingBasket.Models.ShoppingBasket
            {
                Items = new List<IItem>
                {
                    new Item{PricePerItem = itemOnePrice,Qty = itemOneQty},
                    new Item{PricePerItem = itemTwoPrice,Qty = itemTwoQty}
                }
            };

            //Act
            var result = _sut.TotalCost();

            //Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void TotalCost_WithDiscount()
        {
            //Arrange
            _sut = new BusinessCore.Areas.ShoppingBasket.Models.ShoppingBasket
            {
                Items = new List<IItem>
                {
                    new Item{PricePerItem = 10,Qty = 5,Sku = "A"},
                    new Item{PricePerItem = 5,Qty = 2, Sku = "B"}
                },
                Discounts = new List<IDiscount>
                {
                new Discount{PricePerOffer = -5,Qty = 2,Sku = "A"},
                new Discount{PricePerOffer = -2.5,Qty = 1,Sku = "B"}
                }
            };

            //Act
            var result = _sut.TotalCost();

            //Assert
            result.Should().Be(47.5);
        }

        //TODO add more discount tests.
    }
}
