using System;
using System.Collections.Generic;
using System.Text;

namespace TaskCore.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
