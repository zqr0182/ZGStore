

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class GiftRegistryProduct : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int GiftRegistryID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("GiftRegistryID")]
        public virtual GiftRegistry GiftRegistry { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
