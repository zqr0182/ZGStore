using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IUserService
    {
        User FindByUserName(string userName);
        List<UserViewModel> GetUsers(bool? active);
        User GetUserById(int id);
        void Upsert(List<UserViewModel> users);
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

        public List<UserViewModel> GetUsers(bool? active)
        {
            var usersByActive = new UserByActive(active);
            return UnitOfWork.Users.Matches(usersByActive)
                                        .Select(u => new UserViewModel
                                        {
                                            UserId = u.UserId,
                                            UserName = u.UserName,
                                            FirstName = u.FirstName,
                                            LastName = u.LastName,
                                            Phone = u.Phone,
                                            DateCreated = u.DateCreated,
                                            DateUpdated = u.DateUpdated,
                                            Active = u.Active
                                        }).ToList();
        }

        public User GetUserById(int id)
        {
            return UnitOfWork.Users.Matches(new UserById(id)).FirstOrDefault();
        }

        public void Upsert(List<UserViewModel> users)
        {
            users.ForEach(u => Upsert(u));

            UnitOfWork.Commit();
        }

        private void Upsert(UserViewModel user)
        {
            if (user.UserId > 0)
            {
                Update(user);
            }
            else
            {
                Create(user);
            }
        }

        private void Update(UserViewModel user)
        {
            var u = GetUserById(user.UserId);

            if (u != null)
            {
                UpdateUser(u, user);
            }
        }

        private void Create(UserViewModel user)
        {
            var u = new User() { DateCreated = DateTime.Now};
            UpdateUser(u, user);

            UnitOfWork.Users.Add(u);
        }

        private void UpdateUser(User userInDb, UserViewModel user)
        {
            userInDb.UserName = user.UserName;
            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Phone = user.Phone;
            userInDb.DateUpdated = DateTime.Now;
            userInDb.Active = user.Active;
        }
    }
}
