using BusinessCore.Areas.ShoppingBasket.Models;
using FluentAssertions;
using Xunit;

namespace BusinessCore.Tests.Areas.ShoppingBasket
{
    public class ItemTests
    {
    private IItem _sut; 

    [Theory]
    [InlineData("A","A")]
    [InlineData("B","B")]
    [InlineData("C","C")]
    public void Sku_Success(string sku, string expectedResult)
    {
    //Arrange
    _sut = new Item
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
    public void TotalOfferPrice_Success(int qty,double price, double expectedResult)
    {
    //Arrange
    _sut = new Item()
    {
        Qty = qty,
        PricePerItem = price,
    };

    //Act
    var result = _sut.Total();

    //Assert
    result.Should().Be(expectedResult);
    }
    }
}

