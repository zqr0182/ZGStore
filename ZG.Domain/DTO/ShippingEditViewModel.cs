using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ShippingEditViewModel
    {
        [Key]
        public int Id { get; set; }
        public int CountryID { get; set; }
        public StateIdName StateIdName { get; set; }
        public string City { get; set; }
        public ProvinceIdName ProvinceIdName { get; set; }
        public ProductIdName ProductIdName { get; set; }
        public ShippingProviderIdName ShippingProviderIdName { get; set; }
        public decimal Rate { get; set; }
        public bool Active { get; set; }
    }
}
