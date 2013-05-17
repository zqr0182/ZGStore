

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZG.Domain.Models
{
    public partial class State : IEntity  
    {
        public State()
        {
            this.Addresses = new List<Address>();
            this.Orders = new List<Order>();
            this.Shippings = new List<Shipping>();
            this.Taxes = new List<Tax>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string StateName { get; set; }
        [Required]
        [MaxLength(2)]
        public string StateCode { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
