using System;
using System.Collections.Generic;
using System.Text;
using LumiBeam.Domain.Common;

namespace LumiBeam.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string SKU { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
