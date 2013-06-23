using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
        IRepository<Email> Emails { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderStatus> OrderStatuses { get; }
        IRepository<ShippingProvider> ShippingProviders { get; }

        void Commit();
    }

    public class ZGStoreUnitOfWork : IUnitOfWork
    {
        private readonly ZGStoreContext _context;

        public IRepository<Product> Products { get; private set; }
        public IRepository<User> Users { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Email> Emails { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderStatus> OrderStatuses { get; private set; }
        public IRepository<ShippingProvider> ShippingProviders { get; private set; }

        public ZGStoreUnitOfWork(ZGStoreContext context, IRepository<Product> productRepo, IRepository<User> userRepo, IRepository<Category> categoryRepo, IRepository<Email> emailRepo,
                                 IRepository<Order> OrderRepo, IRepository<OrderStatus> orderStatusRepo, IRepository<ShippingProvider> shippingProvidersRepo)
        {
            _context = context;

            Products = productRepo;
            Users = userRepo;
            Categories = categoryRepo;
            Emails = emailRepo;
            Orders = OrderRepo;
            OrderStatuses = orderStatusRepo;
            ShippingProviders = shippingProvidersRepo;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
