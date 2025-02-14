using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Entities
{
    public class SaleTests
    {
        [Fact]
        public void ShouldApply10PercentDiscount_WhenQuantityIsBetween4And9()
        {
            var item = new SaleItem("Cerveja", 5, 10.00m);
            item.ApplyDiscount(0.10m);

            Assert.Equal(45.00m, item.TotalAmount);
        }

        [Fact]
        public void ShouldApply20PercentDiscount_WhenQuantityIsBetween10And20()
        {
            var item = new SaleItem("Cerveja", 15, 10.00m);
            item.ApplyDiscount(0.20m);

            Assert.Equal(120.00m, item.TotalAmount); 
        }

        [Fact]
        public void ShouldNotAllowMoreThan20Items()
        {
            var exception = Assert.Throws<Exception>(() => new SaleItem("Cerveja", 25, 10.00m));
            Assert.Equal("Não é permitido vender mais de 20 itens idênticos.", exception.Message);
        }

        [Fact]
        public void ShouldNotApplyDiscount_WhenQuantityIsLessThan4()
        {
            var item = new SaleItem("Cerveja", 3, 10.00m);
            
            
            
            Assert.Equal(30.00m, item.TotalAmount); 
        }

        [Fact]
        public void ShouldCalculateTotalAmountCorrectly()
        {
            var sale = SalesTestData.GetSampleSale(); 
            sale.CalculateTotal();

            Assert.Equal(195.00m, sale.TotalAmount);
        }
    }
}
