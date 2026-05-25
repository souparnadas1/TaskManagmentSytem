using System;
using System.Collections.Generic;
using System.Text;

namespace TaskCore.Entity
{
    public class Taskcategory : BaseEntity
    {
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
