using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class Email
    {
        public int IdEmail { get; set; }
        public string EmailAddress { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
    }
}
