using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IStateService
    {
        List<IdName> GetStateIdNames(bool active);
    }

    public class StateService : BaseService, IStateService
    {
        public StateService(IUnitOfWork uow)
            : base(uow)
        {}
        
        public List<IdName> GetStateIdNames(bool active)
        {
            var stateByActive = new StatesByActive(active);
            return UnitOfWork.States.Matches(stateByActive)
                                       .Select(p => new IdName { Id = p.Id, Name = p.Name }).ToList();
        }
    }
}
