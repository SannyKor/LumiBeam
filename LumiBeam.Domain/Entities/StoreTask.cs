using LumiBeam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using LumiBeam.Domain.Common;
using LumiBeam.Domain.Entities;
using LumiBeam.Domain.Enums;

namespace LumiBeam.Domain.Entities
{
    public class StoreTask : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }

        public TaskState Status { get; set; } = TaskState.ToDo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        // Хто призначив (старший продавець / адмін)
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;

        // Кому призначено (null, якщо завдання спільне на всю зміну)
        public int? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
