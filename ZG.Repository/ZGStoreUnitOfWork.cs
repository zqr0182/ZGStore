using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }

        void Commit();
    }

    public class ZGStoreUnitOfWork : IUnitOfWork
    {
        private readonly ZGStoreContext _context;

        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public ZGStoreUnitOfWork(ZGStoreContext context, IProductRepository productRepo, IUserRepository userRepo, ICategoryRepository categoryRepo)
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
