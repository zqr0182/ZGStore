using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ShippingByCountry : AbstractCriteria<Shipping>
    {
        private int _countryId;

        public ShippingByCountry(int countryId, ICriteria<Shipping> initialCriteria = null)
            : base(initialCriteria)
        {
            _countryId = countryId;
        }

        public override IQueryable<Shipping> BuildQueryOver(IQueryable<Shipping> queryBase)
        {
            IQueryable<Shipping> shippings = base.BuildQueryOver(queryBase);

            return shippings.Where(s => s.CountryID == _countryId);
        }
    }
}
