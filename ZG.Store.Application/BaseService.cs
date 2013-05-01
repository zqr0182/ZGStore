using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Repository;

namespace ZG.Store.Application
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
