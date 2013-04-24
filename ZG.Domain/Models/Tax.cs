

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Tax : IEntity  
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public bool Fixed { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public bool IsAfterShipping { get; set; }
        public int CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public bool Active { get; set; }
        public virtual Country Country { get; set; }
        public virtual Province Province { get; set; }
        public virtual State State { get; set; }
    }
}
