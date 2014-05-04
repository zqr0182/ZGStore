using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ShippingViewModel
    {
        [Key]
        public int Id { get; set; }
        public int CountryID { get; set; }
        public int? StateID { get; set; }
        public string City { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public int ProductID { get; set; }
        public int ShippingProviderID { get; set; }
        public decimal Rate { get; set; }
        public bool Active { get; set; }
    }
}
