

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class ProductTag : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int TagID { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [Required]
        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}
