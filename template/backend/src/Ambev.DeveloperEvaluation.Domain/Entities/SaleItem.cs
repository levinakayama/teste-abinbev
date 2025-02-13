using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount => (UnitPrice * Quantity) - Discount;

        public SaleItem(string productName, int quantity, decimal unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void ApplyDiscount(decimal percentage)
        {
            Discount = (UnitPrice * Quantity) * percentage;
        }

        public void RemoveDiscount()
        {
            Discount = 0;
        }
    }
}
