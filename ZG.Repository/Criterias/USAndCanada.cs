using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class USAndCanada : AbstractCriteria<Country>
    {
        public USAndCanada()
        {
        }

        public override IQueryable<Country> BuildQueryOver(IQueryable<Country> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(c => c.CountryName == "UNITED STATES" || c.CountryName == "CANADA").OrderByDescending(c => c.CountryName);
        }
    }
}