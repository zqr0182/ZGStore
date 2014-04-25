using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Supplier : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Zip { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30)]
        public string Fax { get; set; }
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string WebSite { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Note { get; set; }
        [Required]
        [MaxLength(30)]
        public string ContactFName { get; set; }
        [Required]
        [MaxLength(30)]
        public string ContactLName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContactTitle { get; set; }

    }
}
