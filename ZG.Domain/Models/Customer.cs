

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Customer : IEntity  
    {
        public Customer()
        {
            this.GiftRegistries = new List<GiftRegistry>();
            this.ProductReviews = new List<ProductReview>();
        }

        public int Id { get; set; }
        public System.Guid MemberID { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Zipcode { get; set; }
        public string DayPhone { get; set; }
        public string EveningPhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public bool Active { get; set; }
        public virtual Country Country { get; set; }
        public virtual Province Province { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<GiftRegistry> GiftRegistries { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
