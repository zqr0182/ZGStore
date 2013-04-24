

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class RelatedProduct : IEntity  
    {
        public int Id { get; set; }
        public int ProductOneID { get; set; }
        public int ProductTwoID { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual Product Product { get; set; }
        public virtual Product Product1 { get; set; }
    }
}
