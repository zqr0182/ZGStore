

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Common;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class User : IEntity
    {
        [NotMapped]
        public int Id { get; set; }
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        public System.DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<GiftRegistry> GiftRegistries { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
