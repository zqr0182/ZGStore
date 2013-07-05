using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProvincesByActive : AbstractCriteria<Province>
    {
        private bool _activeOnly;

        public ProvincesByActive(bool activeOnly)
        {
            _activeOnly = activeOnly;
        }

        public override IQueryable<Province> BuildQueryOver(IQueryable<Province> queryBase)
        {
            IQueryable<Province> provinces = base.BuildQueryOver(queryBase);

            if (_activeOnly)
            {
                provinces = provinces.Where(s => (s.Active.HasValue && s.Active.Value == true));
            }

            return provinces;
        }
    }
}
