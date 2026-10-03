using System;
using System.Collections.Generic;
using System.Text;
using LumiBeam.Domain.Common;

namespace LumiBeam.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
