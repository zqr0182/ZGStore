using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Application
{
    public interface IInventoryService
    {
        List<Inventory> GetInventories();
    }

    public class InventoryService : BaseService, IInventoryService
    {
        public InventoryService(IUnitOfWork uow) : base(uow)
        { }

        public List<Inventory> GetInventories()
        {
            return null;
        }
    }
}
