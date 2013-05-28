

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Tag : IEntity  
    {
        public Tag()
        {
            this.ProductTags = new List<ProductTag>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
