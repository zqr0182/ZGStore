using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProvinceByCountry : AbstractCriteria<Province>
    {
        private int _countryId;

        public ProvinceByCountry(int countryId, ICriteria<Province> initialCriteria = null)
            : base(initialCriteria)
        {
            _countryId = countryId;
        }

        public override IQueryable<Province> BuildQueryOver(IQueryable<Province> queryBase)
        {
            IQueryable<Province> provinces = base.BuildQueryOver(queryBase);

            return provinces.Where(s => s.CountryId == _countryId);
        }
    }
}
