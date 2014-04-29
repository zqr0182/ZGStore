using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProvinceByActive : AbstractCriteria<Province>
    {
        private bool? _active;

        public ProvinceByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Province> BuildQueryOver(IQueryable<Province> queryBase)
        {
            IQueryable<Province> provinces = base.BuildQueryOver(queryBase);

            provinces = provinces.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));

            return provinces;
        }
    }
}
