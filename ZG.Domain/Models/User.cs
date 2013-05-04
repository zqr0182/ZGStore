

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Common;

namespace ZG.Domain.Models
{
    public partial class User : IEntity
    {
        public User()
        {
            this.Addresses = new List<Address>();
            this.GiftRegistries = new List<GiftRegistry>();
            this.ProductReviews = new List<ProductReview>();
        }

        [NotMapped]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public System.DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<GiftRegistry> GiftRegistries { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
