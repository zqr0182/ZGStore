using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Store.Application
{
    public interface ICategoryService
    {
        IEnumerable<string> GetActiveCategoryNames();
    }

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<string> GetActiveCategoryNames()
        {
            return UnitOfWork.Categories.GetActiveCategoryNames();
        }
    }
}
