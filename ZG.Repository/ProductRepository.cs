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
        ProductsPerPage GetActiveProducts(string category, int page, int pageSize);
        Product GetProductById(int id);
    }

    public class ProductRepository : ZGStoreRepository<Product>, IProductRepository
    {
        public ProductRepository(ZGStoreContext context) : base(context){}

        public ProductsPerPage GetActiveProducts(string category, int page, int pageSize)
        {
            return GetProducts(category, page, pageSize, true);
        }

        private ProductsPerPage GetProducts(string category, int page, int pageSize, bool activeOnly)
        {
            var prodsInCategory = (from prod in _dbSet
                                   join prodCat in _context.ProductCategories on prod.Id equals prodCat.ProductID
                                   join cat in _context.Categories on prodCat.CategoryID equals cat.Id
                                   where prod.Active == activeOnly && (category == null || cat.CategoryName == category)
                                   select prod);

            int totalProducts = prodsInCategory.Count();

            var products = prodsInCategory.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);

            var productsPerPage = new ProductsPerPage
            {
                Products = products,
                TotalProducts = totalProducts
            };

            return productsPerPage;
        }

        public Product GetProductById(int id)
        {
            return FindWhere(p => p.Id == id).FirstOrDefault();
        }
    }
}
