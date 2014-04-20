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
        [MaxLength(50)]
        public string Status { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }
        [Required]
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
        [MaxLength(50)]
        public string Phone { get; set; }
    }
}
