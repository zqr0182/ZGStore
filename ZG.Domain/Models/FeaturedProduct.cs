

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class FeaturedProduct : IEntity  
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public bool Active { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
