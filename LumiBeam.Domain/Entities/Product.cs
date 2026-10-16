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

        public decimal RetailPrice { get; set; }
        public decimal BonusPerUnit { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<SaleRecord> SaleRecords { get; set; } = new List<SaleRecord>();
    }
}
