using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetActiveProducts();
    }

    public class ProductRepository : ZGStoreRepository<Product>, IProductRepository
    {
        public ProductRepository(ZGStoreContext context) : base(context){}

        public IQueryable<Product> GetActiveProducts()
        {
            return FindWhere(p => p.Active);
        }
    }
}
