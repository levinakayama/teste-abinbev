using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class SalesService
    {
        private readonly List<Sale> _sales = new();

        public Sale CreateSale(string saleNumber, DateTime saleDate, string customer, string branch, List<SaleItem> items)
        {
            var sale = new Sale(saleNumber, saleDate, customer, branch);
            foreach (var item in items)
            {
                sale.AddItem(item);
            }

            _sales.Add(sale);
            return sale;
        }

        public List<Sale> GetAllSales()
        {
            return _sales;
        }

        public Sale GetSaleById(Guid saleId)
        {
            return _sales.FirstOrDefault(s => s.Id == saleId);
        }

        public void CancelSale(Guid saleId)
        {
            var sale = GetSaleById(saleId);
            if (sale == null)
                throw new Exception("Venda não encontrada.");

            sale.CancelSale();
        }
    }
}
