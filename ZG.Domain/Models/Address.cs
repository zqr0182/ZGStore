

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Address : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        public int CountryID { get; set; }
        public int? StateID { get; set; }
        public int? ProvinceID { get; set; }
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
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
 
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
