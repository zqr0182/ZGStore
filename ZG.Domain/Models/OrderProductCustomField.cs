

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class OrderProductCustomField : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int OrderProductID { get; set; }
        public int CustomFieldID { get; set; }
        [MaxLength(400)]
        public string OrderProductCustomFieldValue { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CustomFieldID")]
        public virtual CustomField CustomField { get; set; }
        [Required]
        [ForeignKey("OrderProductID")]
        public virtual OrderProduct OrderProduct { get; set; }
    }
}
