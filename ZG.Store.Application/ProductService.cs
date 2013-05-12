using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;

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
            return UnitOfWork.Products.GetActiveProducts(category, page, pageSize);
        }

        public Product GetProductById(int id)
        {
            return UnitOfWork.Products.GetProductById(id);
        }
    }
}
