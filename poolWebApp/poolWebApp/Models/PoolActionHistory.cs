﻿using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class PoolActionHistory
    {
        public long IdPoolActionHistory { get; set; }
        public int IdPool { get; set; }
        public string Identification { get; set; }
        public int IdStatus { get; set; }
        public int IdProperty { get; set; }
        public int? IdUser { get; set; }
        public string Value { get; set; }
        public DateTimeOffset? ValueDateTime { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }
        public DateTimeOffset? UpdDateTime { get; set; }
        public bool? IsAlarm { get; set; }

        public virtual Pool IdPoolNavigation { get; set; }
        public virtual Property IdPropertyNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
