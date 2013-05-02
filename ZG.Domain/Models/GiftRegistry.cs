

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class GiftRegistry : IEntity  
    {
        public GiftRegistry()
        {
            this.GiftRegistryProducts = new List<GiftRegistryProduct>();
        }

        public int Id { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsPublic { get; set; }
        public bool Active { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GiftRegistryProduct> GiftRegistryProducts { get; set; }
    }
}
