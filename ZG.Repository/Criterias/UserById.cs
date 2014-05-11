using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class UserById : AbstractCriteria<User>
    {
        private readonly int _userId;

        public UserById(int userId)
        {
            _userId = userId;
        }

        public override IQueryable<User> BuildQueryOver(IQueryable<User> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(u => u.UserId == _userId);
        }
    }
}
