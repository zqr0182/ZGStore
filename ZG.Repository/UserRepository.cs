using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string email);
    }

    public class UserRepository : ZGStoreRepository<User>, IUserRepository
    {
        public UserRepository(ZGStoreContext context) : base(context){}

        public User FindByUserName(string userName)
        {
            return FindWhere(p => p.UserName == userName).SingleOrDefault();
        }

        public override User FindById(int id)
        {
            return FindWhere(u => u.UserId == id).SingleOrDefault();
        }
    }
}
