using LumiBeam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using LumiBeam.Domain.Common;

namespace LumiBeam.Domain.Entities
{
    public class User : BaseEntity
    {
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Seller;
        public string StoreLocation { get; set; } = string.Empty;

        // Зв'язки

        public ICollection<SaleRecord> SaleRecords { get; set; } = new List<SaleRecord>();
        public ICollection<StoreTask> AssignedTasks { get; set; } = new List<StoreTask>();
    }
}
