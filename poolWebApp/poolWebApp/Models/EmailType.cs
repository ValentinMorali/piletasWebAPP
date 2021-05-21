using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class EmailType
    {
        public EmailType()
        {
            StatusEmailTypes = new HashSet<StatusEmailType>();
        }

        public long IdEmailType { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }

        public virtual ICollection<StatusEmailType> StatusEmailTypes { get; set; }
    }
}
