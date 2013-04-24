

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class GiftRegistryProduct : IEntity  
    {
        public int Id { get; set; }
        public int GiftRegistryID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public bool Active { get; set; }
        public virtual GiftRegistry GiftRegistry { get; set; }
        public virtual Product Product { get; set; }
    }
}
