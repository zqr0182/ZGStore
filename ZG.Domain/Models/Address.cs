

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Address : IEntity  
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zipcode { get; set; }
        public System.DateTime CreationDate { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
        public virtual Country Country { get; set; }
        public virtual Province Province { get; set; }
        public virtual State State { get; set; }
        public virtual Users User { get; set; }
    }
}
