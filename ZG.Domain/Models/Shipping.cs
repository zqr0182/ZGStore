

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class Shipping : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public int ProductID { get; set; }
        public int ShippingProviderID { get; set; }
        public decimal Rate { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }
        [Required]
        [ForeignKey("ShippingProviderID")]
        public virtual ShippingProvider ShippingProvider { get; set; }
        [Required]
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
    }
}
