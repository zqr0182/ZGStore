using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByProductId(int prodId);
    }

    public class InventoryService : BaseService, IInventoryService
    {
        public InventoryService(IUnitOfWork uow) : base(uow)
        { }

        public List<Inventory> GetInventoriesByProductId(int prodId)
        {
            return UnitOfWork.Inventories.Matches(new InventoryByProductId(prodId)).ToList();
        }
    }
}
