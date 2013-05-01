using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Store.Application
{
    public interface IProductService
    {
        IQueryable<Product> GetActiveProducts();
    }

    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork uow) : base(uow)
        {
        }

        public IQueryable<Product> GetActiveProducts()
        {
            return UnitOfWork.Products.GetActiveProducts();
        }
    }
}
