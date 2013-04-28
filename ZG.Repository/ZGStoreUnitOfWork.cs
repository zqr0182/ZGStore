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
        void Commit();
    }

    public class ZGStoreUnitOfWork : IUnitOfWork
    {
        private readonly ZGStoreContext _context;

        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; private set; }

        public ZGStoreUnitOfWork(ZGStoreContext context, IProductRepository productRepository, IUserRepository userRepository)
        {
            _context = context;
            Products = productRepository;
            Users = userRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
