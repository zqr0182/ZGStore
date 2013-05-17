

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class ProductCategory : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
