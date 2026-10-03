using System;
using System.Collections.Generic;
using System.Text;
using LumiBeam.Domain.Common;

namespace LumiBeam.Domain.Entities
{
    public class SaleRecord : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPriceSnapshot { get; set; }
        public decimal BonusPerUnitSnapshot { get; set; }

        // Розрахункові показники
        public decimal TotalAmount => UnitPriceSnapshot * Quantity;
        public decimal TotalBonus => BonusPerUnitSnapshot * Quantity;
    }
}
