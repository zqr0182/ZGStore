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
        ProductsPerPage GetProducts(string category, int page, int pageSize);
    }

    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork uow) : base(uow)
        {
        }

        public ProductsPerPage GetProducts(string category, int page, int pageSize)
        {
            return UnitOfWork.Products.GetProducts(category, page, pageSize);
        }
    }
}
