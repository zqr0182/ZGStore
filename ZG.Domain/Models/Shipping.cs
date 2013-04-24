

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Shipping : IEntity  
    {
        public int Id { get; set; }
        public int CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public int ProductID { get; set; }
        public int ShippingProviderID { get; set; }
        public decimal Rate { get; set; }
        public bool Active { get; set; }
        public virtual Country Country { get; set; }
        public virtual Product Product { get; set; }
        public virtual Province Province { get; set; }
        public virtual ShippingProvider ShippingProvider { get; set; }
        public virtual State State { get; set; }
    }
}
