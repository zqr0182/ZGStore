

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class GiftRegistry : IEntity  
    {
        public GiftRegistry()
        {
            this.GiftRegistryProducts = new List<GiftRegistryProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsPublic { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<GiftRegistryProduct> GiftRegistryProducts { get; set; }
    }
}
