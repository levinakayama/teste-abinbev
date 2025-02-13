using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _salesService;

        public SalesController()
        {
            _salesService = new SalesService();
        }

        [HttpPost]
        public IActionResult CreateSale([FromBody] SaleRequest request)
        {
            var items = new List<SaleItem>();
            foreach (var item in request.Items)
            {
                items.Add(new SaleItem(item.ProductName, item.Quantity, item.UnitPrice));
            }

            var sale = _salesService.CreateSale(request.SaleNumber, request.SaleDate, request.Customer, request.Branch, items);
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            return Ok(_salesService.GetAllSales());
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(Guid id)
        {
            var sale = _salesService.GetSaleById(id);
            if (sale == null)
                return NotFound("Venda não encontrada.");

            return Ok(sale);
        }

        [HttpDelete("{id}")]
        public IActionResult CancelSale(Guid id)
        {
            try
            {
                _salesService.CancelSale(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

    public class SaleRequest
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<SaleItemRequest> Items { get; set; }
    }

    public class SaleItemRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
