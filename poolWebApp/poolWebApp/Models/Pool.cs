using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class Pool
    {
        public Pool()
        {
            PoolActionHistories = new HashSet<PoolActionHistory>();
            PoolActions = new HashSet<PoolAction>();
            PoolStatusEmailHistories = new HashSet<PoolStatusEmailHistory>();
            PoolStatusEmails = new HashSet<PoolStatusEmail>();
            PoolStatusProperties = new HashSet<PoolStatusProperty>();
        }

        public int IdPool { get; set; }
        public string Identification { get; set; }
        public bool? Active { get; set; }
        public int? IdStatus { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public bool? SentEmail { get; set; }
        public DateTimeOffset? LastEmail { get; set; }
        public DateTimeOffset? DateTimeToAlarm { get; set; }

        public virtual Status IdStatusNavigation { get; set; }
        public virtual ICollection<PoolActionHistory> PoolActionHistories { get; set; }
        public virtual ICollection<PoolAction> PoolActions { get; set; }
        public virtual ICollection<PoolStatusEmailHistory> PoolStatusEmailHistories { get; set; }
        public virtual ICollection<PoolStatusEmail> PoolStatusEmails { get; set; }
        public virtual ICollection<PoolStatusProperty> PoolStatusProperties { get; set; }
    }
}
