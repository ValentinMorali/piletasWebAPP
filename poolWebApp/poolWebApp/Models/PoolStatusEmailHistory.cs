using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class PoolStatusEmailHistory
    {
        public long IdPoolStatusEmailHistory { get; set; }
        public int IdPool { get; set; }
        public long IdStatusEmailType { get; set; }
        public DateTimeOffset? LastEmail { get; set; }

        public virtual Pool IdPoolNavigation { get; set; }
        public virtual StatusEmailType IdStatusEmailTypeNavigation { get; set; }
    }
}
