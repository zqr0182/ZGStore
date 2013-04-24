

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class ProductTag : IEntity  
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int TagID { get; set; }
        public bool Active { get; set; }
        public virtual Product Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
