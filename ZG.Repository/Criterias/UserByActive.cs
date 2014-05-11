using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class UserByActive : AbstractCriteria<User>
    {
        private bool? _active;

        public UserByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<User> BuildQueryOver(IQueryable<User> queryBase)
        {
            IQueryable<User> users = base.BuildQueryOver(queryBase);

            return users.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
