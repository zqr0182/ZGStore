using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class InventoryViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int ProductAmountOrdered { get; set; }
        [Required]
        public int ProductAmountInStock { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public SupplierIdName SupplierIdName { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
