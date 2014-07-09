using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IOrderStatusService
    {
        List<IdName> GetStatusIdName(bool isActive);
    }

    public class OrderStatusService : BaseService, IOrderStatusService
    {
        public OrderStatusService(IUnitOfWork uow)
            : base(uow)
        {}

        public List<IdName> GetStatusIdName(bool isActive)
        {
            var status = new OrderStatusByActive(isActive);

            return UnitOfWork.OrderStatuses.Matches(status).Select(s => new IdName{ Id = s.Id, Name = s.Name}).ToList();
        }
    }
}
