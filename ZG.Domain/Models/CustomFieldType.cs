

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZG.Domain.Models
{
    public partial class CustomFieldType : IEntity  
    {
        public CustomFieldType()
        {
            this.CustomFields = new List<CustomField>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CustomFieldTypeName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
