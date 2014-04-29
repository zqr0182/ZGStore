using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ProvinceEditViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public CountryIdName CountryIdName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2)]
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
