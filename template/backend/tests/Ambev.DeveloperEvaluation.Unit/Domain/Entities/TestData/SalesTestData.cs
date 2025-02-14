using System;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SalesTestData
    {
       public static Sale GetSampleSale()
{
    var sale = new Sale("123456", DateTime.Now, "Cliente Teste", "Filial SP");

    
    sale.AddItem(new SaleItem("Cerveja Pilsen", 5, 10.00m)); 
    sale.AddItem(new SaleItem("Cerveja Stout", 10, 15.00m)); 
    sale.AddItem(new SaleItem("Cerveja Lager", 3, 10.00m));  

    return sale;
}
    }
}
