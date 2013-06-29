

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class CustomField : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> ProductID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomFieldName { get; set; }
        public int CustomFieldTypeID { get; set; }
        public bool IsRequired { get; set; }
        public bool Active { get; set; }

        [ForeignKey("CustomFieldTypeID")]
        public virtual CustomFieldType CustomFieldType { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProductCustomField> OrderProductCustomFields { get; set; }
    }
}
