

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class State : IEntity  
    {
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
        [InverseProperty("BillingState")]
        public virtual ICollection<Order> OrdersBilling { get; set; }
        [InverseProperty("ShippingState")]
        public virtual ICollection<Order> OrdersShipping { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
