

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class Address : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Zipcode { get; set; }
        public System.DateTime CreationDate { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
        [Required]
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
