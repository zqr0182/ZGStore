

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZG.Domain.Models
{
    public partial class Province : IEntity  
    {
        public Province()
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
        public string ProvinceName { get; set; }
        [Required]
        [MaxLength(2)]
        public string ProvinceCode { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Active { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
