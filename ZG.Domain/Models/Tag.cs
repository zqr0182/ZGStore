

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Tag : IEntity  
    {
        public Tag()
        {
            this.ProductTags = new List<ProductTag>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
