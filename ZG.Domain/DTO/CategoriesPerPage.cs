using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class CategoriesPerPage
    {
        public IEnumerable<Category> Categories { get; set; }
        public int TotalCategories { get; set; }
    }
}
