using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Repository.Criterias
{
    public interface ICriteria<T>
    {
        ZGStoreContext Context { get; set; }
        IQueryable<T> BuildQueryOver(IQueryable<T> queryBase);
    }
}
