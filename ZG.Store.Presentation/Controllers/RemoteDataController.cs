using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZG.Application;

namespace ZG.Store.Presentation.Controllers
{
    public class RemoteDataController : AsyncController
    {
        private IPaymentService _paymentService;

        public RemoteDataController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<string> Index()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " before GetRemoteDataAsync");
            //string data = await _paymentService.GetRemoteDataAsync();

            Task<string> data = _paymentService.GetRemoteDataAsync();
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " after GetRemoteDataAsync");

            string value = await data;

            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " after await data");

            return "aaa";
        }

    }
}
