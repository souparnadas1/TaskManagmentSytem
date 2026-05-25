using System;
using System.Collections.Generic;
using System.Text;

namespace TaskCore.Entity
{
    public class Tasks : BaseEntity
    {
        public int CategoryId { get; set; }
        public Taskcategory Category { get; set; }
        public DateTime TaskTime { get; set; }
        public DateOnly TaskDate { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
    }
}
