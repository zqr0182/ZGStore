using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Repository.Criterias
{
    public abstract class CriteriaBase<T> : ICriteria<T>
    {
        public ZGStoreContext Context { get; set; }
        public abstract IQueryable<T> BuildQueryOver(IQueryable<T> queryBase);
    }
}
