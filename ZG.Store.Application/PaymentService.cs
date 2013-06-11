using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZG.Repository;

namespace ZG.Application
{
    public interface IPaymentService
    {
        Task<string> GetRemoteDataAsync();
    }
    public class PaymentService : BaseService, IPaymentService
    {
        public PaymentService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<string> GetRemoteDataAsync()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " before StartNew");
            return await Task<string>.Factory.StartNew(() =>
                {
                    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " before sleeping");
                    Thread.Sleep(2000);
                    Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " after sleeping");
                    return "Hello";
                });
        }
    }
}
