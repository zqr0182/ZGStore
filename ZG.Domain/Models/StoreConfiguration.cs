

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZG.Domain.Models
{
    public partial class StoreConfiguration 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ConfigKey { get; set; }
        [MaxLength(800)]
        public string ConfigValue { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
