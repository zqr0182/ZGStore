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
        public int CountryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProvinceName { get; set; }
        [MaxLength(2)]
        public string ProvinceCode { get; set; }
        public bool Active { get; set; }
    }
}
