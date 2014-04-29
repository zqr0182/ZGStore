using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class CountryByActive : AbstractCriteria<Country>
    {
        bool? _active;
        public CountryByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Country> BuildQueryOver(IQueryable<Country> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
