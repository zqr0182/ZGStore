

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class FeaturedProduct : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public bool Active { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
