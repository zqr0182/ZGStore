using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class UserByName : CriteriaBase<User>
    {
        private readonly string _name;

        public UserByName(string name)
        {
            _name = name;
        }

        public override IQueryable<User> BuildQueryOver(IQueryable<User> queryBase)
        {
            return queryBase.Where(u => u.UserName == _name);
        }
    }
}
