using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IUserRepository : IRepository<Users>
    {
        Users FindByEmail(string email);
    }

    public class UserRepository : ZGStoreRepository<Users>, IUserRepository
    {
        public UserRepository(ZGStoreContext context) : base(context){}

        public Users FindByEmail(string email)
        {
            return FindWhere(p => p.Email == email).SingleOrDefault();
        }

        public override Users FindById(int id)
        {
            return FindWhere(u => u.UserId == id).SingleOrDefault();
        }
    }
}
