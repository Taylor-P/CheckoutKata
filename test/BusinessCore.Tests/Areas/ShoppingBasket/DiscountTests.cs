using BusinessCore.Areas.ShoppingBasket.Models;
using Xunit;
using FluentAssertions;

namespace BusinessCore.Tests.Areas.ShoppingBasket
{
    public class DiscountTests
    {
        private IDiscount _sut; 

        [Theory]
        [InlineData("A","A")]
        [InlineData("B","B")]
        [InlineData("C","C")]
        public void Sku_Success(string sku, string expectedResult)
        {
            //Arrange
            _sut = new Discount
            {
                Sku = sku
            };

            //Act
            var result = _sut.Sku;

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(5,10,50)]
        [InlineData(100,10,1000)]
        [InlineData(2,5,10)]
        [InlineData(9,9,81)]
        [InlineData(6,10,60)]
        [InlineData(1,3,3)]
        public void TotalOfferPrice_Success(int qty,double offerPrice, double expectedResult)
        {
            //Arrange
            _sut = new Discount
            {
                Qty = qty,
                PricePerOffer = offerPrice,
            };

            //Act
            var result = _sut.TotalOfferPrice();

            //Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Offer1","Offer1")]
        [InlineData("Offer2","Offer2")]
        [InlineData("Offer3","Offer3")]
        public void OfferText_Success(string offerText, string expectedResult)
        {
            //Arrange
            _sut = new Discount
            {
                OfferText = offerText
            };

            //Act
            var result = _sut.OfferText;

            //Assert
            result.Should().Be(expectedResult);
        }
    }
}
