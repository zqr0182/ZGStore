

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class OrderProductOption : IEntity  
    {
        public int Id { get; set; }
        public int OrderProductID { get; set; }
        public int ProductOptionID { get; set; }
        public bool Active { get; set; }
        public virtual OrderProduct OrderProduct { get; set; }
        public virtual ProductOption ProductOption { get; set; }
    }
}
