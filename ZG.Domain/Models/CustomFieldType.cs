

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class CustomFieldType : IEntity  
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CustomFieldTypeName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
