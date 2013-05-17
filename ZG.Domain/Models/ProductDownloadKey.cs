

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZG.Domain.Models
{
    public partial class ProductDownloadKey : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        [Required]
        [MaxLength(50)]
        public string DownloadKey { get; set; }
        public bool Active { get; set; }
        [Required]
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
