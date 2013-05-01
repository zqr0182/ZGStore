using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Store.Application
{
    public interface IUserService
    {
        Users FindByEmail(string email);
    }

    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public Users FindByEmail(string email)
        {
            return UnitOfWork.Users.FindByEmail(email);
        }
    }
}
