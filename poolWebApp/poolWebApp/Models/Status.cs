using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class Status
    {
        public Status()
        {
            PoolActionHistories = new HashSet<PoolActionHistory>();
            PoolActions = new HashSet<PoolAction>();
            PoolStatusProperties = new HashSet<PoolStatusProperty>();
            Pools = new HashSet<Pool>();
            StatusEmailTypeIdStatusNavigations = new HashSet<StatusEmailType>();
            StatusEmailTypeIdStatusNextPoolNavigations = new HashSet<StatusEmailType>();
        }

        public int IdStatus { get; set; }
        public string Name { get; set; }
        public bool? EmailAlert { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public string Color { get; set; }

        public virtual ICollection<PoolActionHistory> PoolActionHistories { get; set; }
        public virtual ICollection<PoolAction> PoolActions { get; set; }
        public virtual ICollection<PoolStatusProperty> PoolStatusProperties { get; set; }
        public virtual ICollection<Pool> Pools { get; set; }
        public virtual ICollection<StatusEmailType> StatusEmailTypeIdStatusNavigations { get; set; }
        public virtual ICollection<StatusEmailType> StatusEmailTypeIdStatusNextPoolNavigations { get; set; }
    }
}
