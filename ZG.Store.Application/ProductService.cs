using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Store.Application
{
    public interface IProductService
    {
        ProductsPerPage GetActiveProducts(string category, int page, int pageSize);
        Product GetProductById(int id);
    }

    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork uow) : base(uow)
        {
        }

        public ProductsPerPage GetActiveProducts(string category, int page, int pageSize)
        {
            var productsByCategory = new ProductsByCategory(category, true);
            IQueryable<Product> products = UnitOfWork.Products.Matches(productsByCategory);

            int totalProducts = products.Count();

            //products = products.Matches(new ProductsByPage(page, pageSize)); //This also works
            products = UnitOfWork.Products.Matches(new ProductsByPage(page, pageSize, productsByCategory));

            var productsPerPage = new ProductsPerPage
            {
                Products = products,
                TotalProducts = totalProducts
            };

            return productsPerPage;
        }

        public Product GetProductById(int id)
        {
            return UnitOfWork.Products.MatcheById(id);
        }
    }
}
