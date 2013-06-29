

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class GiftRegistry : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsPublic { get; set; }
        public bool Active { get; set; }
      
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<GiftRegistryProduct> GiftRegistryProducts { get; set; }
    }
}
