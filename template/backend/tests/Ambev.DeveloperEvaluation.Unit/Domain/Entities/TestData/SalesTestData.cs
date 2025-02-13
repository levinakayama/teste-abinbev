using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.TestData
{
    public static class SaleTestData
    {
        public static Sale GetSampleSale()
        {
            return new Sale("123456", DateTime.Now, "Cliente Teste", "São Paulo")
            {
                Items = new List<SaleItem>
                {
                    new SaleItem("Cerveja Pilsen", 5, 10.00m),
                    new SaleItem("Cerveja Lager", 12, 15.00m)
                }
            };
        }
    }
}
