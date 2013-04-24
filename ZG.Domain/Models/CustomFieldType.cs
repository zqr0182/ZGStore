

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class CustomFieldType : IEntity  
    {
        public CustomFieldType()
        {
            this.CustomFields = new List<CustomField>();
        }

        public int Id { get; set; }
        public string CustomFieldTypeName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
