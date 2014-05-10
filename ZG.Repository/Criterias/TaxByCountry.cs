using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class TaxByCountry : AbstractCriteria<Tax>
    {
        private int _countryId;

        public TaxByCountry(int countryId, ICriteria<Tax> initialCriteria = null)
            : base(initialCriteria)
        {
            _countryId = countryId;
        }

        public override IQueryable<Tax> BuildQueryOver(IQueryable<Tax> queryBase)
        {
            IQueryable<Tax> taxes = base.BuildQueryOver(queryBase);

            return taxes.Where(s => s.CountryID == _countryId);
        }
    }
}
