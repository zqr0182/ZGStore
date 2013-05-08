using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Repository
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> sequence, string path)
        {
            var dbQuery = sequence as DbQuery<T>;

            if (dbQuery != null)
            {
                return dbQuery.Include(path);
            }

            return sequence;
        }
    }
}
