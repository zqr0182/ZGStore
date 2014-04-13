using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ProductCategoryEditViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? ParentCategoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
