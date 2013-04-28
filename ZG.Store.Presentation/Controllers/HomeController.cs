using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            using (var context = new ZGStoreContext())
            {
                var uow = new ZGStoreUnitOfWork(context, new ProductRepository(context), new UserRepository(context));

                var user = new Users();
                user.Active = true;
                user.CellPhone = "1111111111";
                user.Company = "company";
                user.DateCreated = DateTime.Now;
                user.DateUpdated = DateTime.Now;
                user.DayPhone = "1111111111";
                user.Email = "test2@hotmail.com";
                user.EveningPhone = "1111111111";
                user.Fax = "";
                user.FirstName = "Charles";
                user.LastName = "Zhang";
                user.UserName = "zhangxiao1234@hotmail.com";

                uow.Users.Add(user);

                uow.Commit();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
