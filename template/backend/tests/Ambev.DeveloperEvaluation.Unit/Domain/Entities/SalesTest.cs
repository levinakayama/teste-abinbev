using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Entities
{
    public class SaleTests
    {
        [Fact]
        public void ShouldApply10PercentDiscount_WhenQuantityIsBetween4And9()
        {
            var item = new SaleItem("Cerveja", 5, 10.00m);
            item.ApplyDiscount(0.10m);

            Assert.Equal(45.00m, item.TotalAmount); // 50 - 10% de desconto
        }

        [Fact]
        public void ShouldApply20PercentDiscount_WhenQuantityIsBetween10And20()
        {
            var item = new SaleItem("Cerveja", 15, 10.00m);
            item.ApplyDiscount(0.20m);

            Assert.Equal(120.00m, item.TotalAmount); // 150 - 20% de desconto
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
            item.ApplyDiscount(0.10m);

            Assert.Equal(30.00m, item.TotalAmount); // Sem desconto
        }

        [Fact]
        public void ShouldCalculateTotalAmountCorrectly()
        {
            var sale = SaleTestData.GetSampleSale();
            sale.CalculateTotal();

            Assert.Equal(225.00m, sale.TotalAmount);
        }
    }
}
