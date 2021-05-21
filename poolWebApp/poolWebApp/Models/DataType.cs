using System;
using System.Collections.Generic;

#nullable disable

namespace poolWebApp.Models
{
    public partial class DataType
    {
        public DataType()
        {
            Properties = new HashSet<Property>();
        }

        public int IdDataType { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? InsDateTime { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
