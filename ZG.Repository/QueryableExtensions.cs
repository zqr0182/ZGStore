using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Repository.Criterias;

namespace ZG.Repository
{
    public static class QueryableExtensions
    {
        //public static IQueryable<T> Include<T>(this IQueryable<T> sequence, string path)
        //{
        //    var dbQuery = sequence as DbQuery<T>;

        //    if (dbQuery != null)
        //    {
        //        return dbQuery.Include(path);
        //    }

        //    return sequence;
        //}

        public static IQueryable<T> Matches<T>(this IQueryable<T> queryBase, ICriteria<T> criteria)
        {
            return criteria.BuildQueryOver(queryBase);
        }
    }
}
