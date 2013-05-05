using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        ProductsPerPage GetProducts(int page, int pageSize);
    }

    public class ProductRepository : ZGStoreRepository<Product>, IProductRepository
    {
        public ProductRepository(ZGStoreContext context) : base(context){}

        public ProductsPerPage GetProducts(int page, int pageSize)
        {
            var products = new ProductsPerPage();
            products.Products = FindWhere(p => p.Active).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);
            products.TotalProducts = FindWhere(p => p.Active).Count();

            return products;
        }
    }
}
