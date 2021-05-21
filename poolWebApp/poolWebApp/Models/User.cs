using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class User
    {
        public User()
        {
            PoolActionHistories = new HashSet<PoolActionHistory>();
            PoolActions = new HashSet<PoolAction>();
        }

        public int IdUser { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<PoolActionHistory> PoolActionHistories { get; set; }
        public virtual ICollection<PoolAction> PoolActions { get; set; }
    }
}
