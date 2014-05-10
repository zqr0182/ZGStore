using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class TaxViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Fixed { get; set; }
        public decimal Amount { get; set; }
        public int CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
