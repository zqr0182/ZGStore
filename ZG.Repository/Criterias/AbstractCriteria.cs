using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Repository.Criterias
{
    public abstract class AbstractCriteria<T> : ICriteria<T>
    {
        protected ICriteria<T> InitialCriteria { get; private set; }
        public ZGStoreContext Context { get; set; }

        protected AbstractCriteria(ICriteria<T> initialCriteria = null)
        {
            InitialCriteria = initialCriteria;
        }

        public virtual IQueryable<T> BuildQueryOver(IQueryable<T> queryBase)
        {
            if (InitialCriteria != null)
            {
                return InitialCriteria.BuildQueryOver(queryBase);
            }

            return queryBase;
        }
    }
}
