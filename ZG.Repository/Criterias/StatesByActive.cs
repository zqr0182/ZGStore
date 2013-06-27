using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class StatesByActive : AbstractCriteria<State>
    {
        private bool _activeOnly;

        public StatesByActive(bool activeOnly)
        {
            _activeOnly = activeOnly;
        }

        public override IQueryable<State> BuildQueryOver(IQueryable<State> queryBase)
        {
            IQueryable<State> states = base.BuildQueryOver(queryBase);

            if (_activeOnly)
            {
                states = states.Where(s => (s.Active.HasValue && s.Active.Value == true));
            }

            return states;
        }
    }
}
