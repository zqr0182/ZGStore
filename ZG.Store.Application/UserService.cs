using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IUserService
    {
        User FindByUserName(string userName);
    }

    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public User FindByUserName(string userName)
        {
            return UnitOfWork.Users.Matches(new UserByName(userName)).FirstOrDefault();
        }
    }
}
