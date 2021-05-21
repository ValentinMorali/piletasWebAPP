using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class StatusEmailType
    {
        public StatusEmailType()
        {
            PoolStatusEmailHistories = new HashSet<PoolStatusEmailHistory>();
            PoolStatusEmails = new HashSet<PoolStatusEmail>();
        }

        public long IdStatusEmailType { get; set; }
        public int? IdStatus { get; set; }
        public int? IdProperty { get; set; }
        public long? IdEmailType { get; set; }
        public TimeSpan? Interval { get; set; }
        public int? IdStatusNextPool { get; set; }

        public virtual EmailType IdEmailTypeNavigation { get; set; }
        public virtual Property IdPropertyNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
        public virtual Status IdStatusNextPoolNavigation { get; set; }
        public virtual ICollection<PoolStatusEmailHistory> PoolStatusEmailHistories { get; set; }
        public virtual ICollection<PoolStatusEmail> PoolStatusEmails { get; set; }
    }
}
