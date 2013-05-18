using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<User> Users { get; }
        IRepository<Category> Categories { get; }

        void Commit();
    }

    public class ZGStoreUnitOfWork : IUnitOfWork
    {
        private readonly ZGStoreContext _context;

        public IRepository<Product> Products { get; private set; }
        public IRepository<User> Users { get; private set; }
        public IRepository<Category> Categories { get; private set; }

        public ZGStoreUnitOfWork(ZGStoreContext context, IRepository<Product> productRepo, IRepository<User> userRepo, IRepository<Category> categoryRepo)
        {
            _context = context;
            Products = productRepo;
            Users = userRepo;
            Categories = categoryRepo;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
