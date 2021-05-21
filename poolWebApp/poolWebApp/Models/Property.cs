using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class Property
    {
        public Property()
        {
            PoolActionHistories = new HashSet<PoolActionHistory>();
            PoolActions = new HashSet<PoolAction>();
            PoolStatusProperties = new HashSet<PoolStatusProperty>();
            StatusEmailTypes = new HashSet<StatusEmailType>();
        }

        public int IdProperty { get; set; }
        public int? IdDataType { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }

        public virtual DataType IdDataTypeNavigation { get; set; }
        public virtual ICollection<PoolActionHistory> PoolActionHistories { get; set; }
        public virtual ICollection<PoolAction> PoolActions { get; set; }
        public virtual ICollection<PoolStatusProperty> PoolStatusProperties { get; set; }
        public virtual ICollection<StatusEmailType> StatusEmailTypes { get; set; }
    }
}
